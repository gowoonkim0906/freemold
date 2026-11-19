$(document).on("input", ".float", function () {
    this.value = this.value.replace(/[^0-9\.]/g, '');
});

$(document).on("input", ".number", function () {
    this.value = this.value.replace(/\D/g, '');
});


function formatDate(value) {
    if (!value) return "";
    return String(value).split("T")[0];
}
//빈값 체크 여부 함수
function hasValue(value) {
    // null, undefined
    if (value === null || value === undefined) return false;

    // 문자열: 공백만 있어도 빈값으로 처리
    if (typeof value === 'string' && value.trim() === '') return false;

    // 배열: 길이 0
    if (Array.isArray(value) && value.length === 0) return false;

    // 객체: 키가 하나도 없을 때 ({})
    if (typeof value === 'object' && !Array.isArray(value) &&
        Object.prototype.toString.call(value) === '[object Object]' &&
        Object.keys(value).length === 0) return false;

    // NaN
    if (typeof value === 'number' && isNaN(value)) return false;

    return true;
}