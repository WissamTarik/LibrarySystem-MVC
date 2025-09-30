// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const SearchInput = document.getElementById("SearchInput")
function ValidationSearch() {
    if (SearchInput.value.trim() == "") {
        return false
    }
    return true;
}
document.getElementById("SearchForm").onsubmit = function (e) {
    if (!ValidationSearch()) {
        e.preventDefault()
    }
}