const API_URL = "http://192.168.0.191:8089/api/client/"; // потом поменяешь
const REFRESH_MS = 1000;
let currentPath = "/";
let selectedFile = null;

function statusClass(status) {
    switch (status) {
        case "PRINTING":
        case "IDLE":
            return "ok";
        case "DISCONNECTED":
            return "warn";
        case "ERROR":
        case "OFFLINE":
            return "err";
        default:
            return "";
    }
}

function render(data) {
    const cls = statusClass(data.status);
    document.getElementById("status").innerHTML = `
        <div class="row"><span class="label">Status:</span><span class="${cls}">${data.status}</span></div>
        <div class="row"><span class="label">Last active:</span>${data.last_active}s ago</div>

        <div class="row"><span class="label">Nozzle temp:</span>${data.nozzle_temp} / ${data.target_nozzle_temp}</div>
        <div class="row"><span class="label">Bed temp:</span>${data.bed_temp} / ${data.target_bed_temp}</div>

        <hr>
        <div class="row"><span class="label">Job:</span>${data.current_job || "-"}</div>
		<div class="row"><span class="label">Layer:</span>${data.current_layer} / ${data.total_layers}</div>
        ${data.error_message ? `
        <div class="row err"><span class="label">Error:</span>${data.error_message}</div>
        ` : ""}
    `;
	updateControls(data.status);
}

async function loadStatus() {
    try {
        const res = await fetch(API_URL + "status", { cache: "no-store" });

        if (!res.ok)
            throw new Error("API error");

        const data = await res.json();
        render(data);
    } catch (e) {
        document.getElementById("status").innerHTML = `
            <div class="row err">OFFLINE</div>
        `;
    }
}
async function loadFiles() {
    const res = await fetch(
        `${API_URL}get_files?path=${encodeURIComponent(currentPath)}`,
        { cache: "no-store" }
    );

    if (!res.ok) {
        alert("Failed to load files");
        return;
    }

    const data = await res.json();

    const box = document.getElementById("files");
    box.innerHTML = "";

    // кнопка "вверх"
    if (currentPath !== "/") {
        box.innerHTML += `<div class="row dir" onclick="up()">[..]</div>`;
    }

    // директории
    if (data.Directories) {
        data.Directories.forEach(d => {
            box.innerHTML += `
                <div class="row dir" onclick="openDir('${d.Name}')">
                    [${d.Name}]
                </div>`;
        });
    }

    // файлы
    if (data.Files) {
        data.Files.forEach(f => {
            box.innerHTML += `
                <div class="row file" onclick="selectFile('${f.Name}')">
                    ${f.Name}
                </div>`;
        });
    }
}

function openDir(name) {
    if (!currentPath.endsWith("/"))
        currentPath += "/";

    currentPath += name;
    loadFiles();
}

function up() {
    if (currentPath === "/") return;

    currentPath = currentPath
        .split("/")
        .slice(0, -1)
        .join("/") || "/";

    loadFiles();
}

async function selectFile(name) {
    const fullPath =
        (currentPath.endsWith("/") ? currentPath : currentPath + "/") + name;

    await fetch(`${API_URL}select_file`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
		body: JSON.stringify({ path: fullPath })
    });

    loadStatus(); // чтобы сразу обновился статус
}

async function upload() {
    const f = document.getElementById("upload").files[0];
    const fd = new FormData();
    fd.append("file", f);

    await fetch(`${API}/files/upload?path=${currentPath}`, {
        method: "POST",
        body: fd
    });

    loadFiles();
}

async function startPrint() {
    if (!selectedFile) {
        alert("No file selected");
        return;
    }

    await fetch(`${API_URL}start_print`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ path: selectedFile })
    });
}

async function stopPrint() {
    await fetch(`${API}stop_print`, { method: "POST" });
}
function updateControls(status) {
    const btnStart = document.getElementById("btn-start");
    const btnStop = document.getElementById("btn-stop");

    // START только в READY
    btnStart.disabled = (status !== "Ready");

    // STOP только при печати
    btnStop.disabled = !(status === "Printing" || status === "Starting");
}
loadFiles();
loadStatus();
setInterval(loadStatus, REFRESH_MS);
