// Allow Tabs in TextAreas
// Solution from: https://stackoverflow.com/questions/6637341/use-tab-to-indent-in-textarea
document.getElementById('Text').addEventListener('keydown', function (e) {
    if (e.key == 'Tab') {
        e.preventDefault();
        var start = this.selectionStart;
        var end = this.selectionEnd;

        // set textarea value to: text before caret + tab + text after caret
        this.value = this.value.substring(0, start) +
            "\t" + this.value.substring(end);

        // put caret at right position again
        this.selectionStart =
            this.selectionEnd = start + 1;
    }
});

var noteToggle = false;

function NoteMenuToggle() {
    if (!noteToggle) {
        document.getElementById("new_note").classList.remove("hide");
        noteToggle = !noteToggle;
    } else {
        document.getElementById("new_note").classList.add("hide");
        noteToggle = !noteToggle;
    }
}