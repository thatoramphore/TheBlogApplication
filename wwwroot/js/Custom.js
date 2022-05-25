let index = 0;

function AddTag() {
    //Get a reference to the TagEntry input element
    var tagEntry = document.getElementById("TagEntry");

    //Create a new select option
    let newOption = new Option(tagEntry.value, tagEntry.value);
    document.getElementById("TagList").options[index++] = newOption;

    //Clear out the TagEntry control
    tagEntry.value = "";
    return true;
}

function DeleteTag() {
    let tagCount = 1;
    
    while (tagCount > 0) {
        //Get index of a selected tag from a TagList
        let tagList = document.getElementById("TagList");
        let selectedIndex = tagList.selectedIndex;
        if (selectedIndex >= 0) {
            //set selected tag to null OR remove tag
            tagList.options[selectedIndex] = null;
            --tagCount
        }
        else
            tagCount = 0;
        index--;
    }
}

$("form").on("submit", function () {
    $("#TagList option").prop("selected", "selected");
})