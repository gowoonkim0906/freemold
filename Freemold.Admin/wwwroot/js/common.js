$(document).on("input", ".float", function () {
    this.value = this.value.replace(/[^0-9\.]/g, '');
});

$(document).on("input", ".number", function () {
    this.value = this.value.replace(/\D/g, '');
});