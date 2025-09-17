const dropZone = document.getElementById("dropZone");
const fileInput = document.getElementById("input_file");
const fileKeep = document.getElementById("file-keep");
const hiddenfile = document.getElementById("hiddenfile");

fileInput.addEventListener("change", () => previewFiles(fileInput.files));
dropZone.addEventListener("click", () => fileInput.click());

dropZone.addEventListener("dragover", e => {
	e.preventDefault();
	dropZone.classList.add("dragover");
});
dropZone.addEventListener("dragleave", e => {
	e.preventDefault();
	dropZone.classList.remove("dragover");
});
dropZone.addEventListener("drop", e => {
	e.preventDefault();
	dropZone.classList.remove("dragover");
	previewFiles(e.dataTransfer.files);
});

function previewFiles(files) {
	const maxCount = parseInt(dropZone.getAttribute("data-max") || "6");  // 기본값 6
	const dt = new DataTransfer();
	const existingFiles = Array.from(fileKeep.files);
	const existingPreviewCount = document.querySelectorAll('.image-preview.existing').length;

	const totalImagesAfterAdd = existingFiles.length + existingPreviewCount + files.length;

	if (totalImagesAfterAdd > maxCount) {
		alert(`최대 ${maxCount}개의 이미지만 업로드할 수 있습니다.`);
		return;
	}


	Array.from(files).forEach(file => {
		if (!file.type.startsWith("image/")) return;

		if (file.size > 5 * 1024 * 1024) {  // 10MB 제한
			alert(`'${file.name}' 파일은 5MB를 초과하여 업로드할 수 없습니다.`);
			return;
		}

		const id = "preview-" + file.lastModified;
		if (document.getElementById(id)) return;
		const reader = new FileReader();
		reader.onload = e => {
			const div = document.createElement("div");
			div.className = "image-preview";
			div.id = id;
			div.setAttribute("data-id", id);
			div.setAttribute("data-type", "new");
			div.innerHTML = `
		  <img src="${e.target.result}" onclick="event.stopPropagation();" >
		  <button class="btn-delete" type="button" onclick="event.stopPropagation();removePreview('${id}', ${file.lastModified})">×</button>`;
			dropZone.appendChild(div);
		};
		reader.readAsDataURL(file);
		dt.items.add(file);
	});
	existingFiles.forEach(f => dt.items.add(f));
	fileKeep.files = dt.files;
	const dropText = document.getElementById("dropText");
	dropText.style.display = 'none';

	fileInput.value = '';
}

function removePreview(id, lastModified) {
	const preview = document.getElementById(id);
	if (preview) preview.remove();
	const dt = new DataTransfer();
	Array.from(fileKeep.files).forEach(f => {
		if (f.lastModified !== lastModified) dt.items.add(f);
	});
	fileKeep.files = dt.files;

	updateDropTextVisibility();
}

function removeExistingImage(id) {
	const el = document.querySelector(`.image-preview.existing[data-id="${id}"]`);
	if (el) el.remove();

	const input = document.getElementById("delete_existing_ids");
	let values = input.value ? input.value.split(",") : [];
	if (!values.includes(id)) values.push(id);
	input.value = values.join(",");

	updateDropTextVisibility();

}

function reorderFiles() {
	const order = Array.from(dropZone.querySelectorAll(".image-preview")).map(div => div.id.split("-")[1]);
	const sorted = order.map(id => Array.from(fileKeep.files).find(f => f.lastModified == id)).filter(f => f);
	const dt = new DataTransfer();
	sorted.forEach(f => dt.items.add(f));
	fileKeep.files = dt.files;
}

function datasave() {
	reorderFiles();
	updateImageOrder();

	/*hiddenfile.innerHTML = "";

	Array.from(fileKeep.files).forEach((file, idx) => {
		const subDt = new DataTransfer();
		subDt.items.add(file);
		const input = document.createElement("input");
		input.type = "file";
		input.style.display = "none";
		input.name = `P_IMG${idx + 1}`;
		input.files = subDt.files;
		hiddenfile.appendChild(input);
	});*/

	$("#image_order").val(getImageOrderString());
}

function updateImageOrder() {
	const previews = document.querySelectorAll(".image-preview");
	const order = [];

	previews.forEach(div => {
		const id = div.getAttribute("data-id");
		const type = div.getAttribute("data-type"); // "existing" or "new"
		order.push(`${type}:${id}`);
	});

	$("#image_order").val(order.join(","));
}

function getImageOrderString() {
	const previews = document.querySelectorAll(".image-preview");
	const order = [];

	previews.forEach(div => {
		const id = div.getAttribute("data-id");
		const type = div.getAttribute("data-type");
		order.push(`${type}:${id}`);
	});

	return order.join(",");
}

function updateDropTextVisibility() {
	const hasImages = document.querySelectorAll(".image-preview").length > 0;
	const dropText = document.getElementById("dropText");

	if (dropText) {
		dropText.style.display = hasImages ? "none" : "block";
	}
}

// jQuery UI Sortable 초기화
$(function () {
	$("#dropZone").sortable({
		items: ".image-preview",
		update: function () {
			reorderFiles();
			updateImageOrder();
		}
	});
});

