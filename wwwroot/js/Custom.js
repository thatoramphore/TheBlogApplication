﻿let index = 0;

function AddTag() {
    //Get a reference to the TagEntry input element
    var tagEntry = document.getElementById("TagEntry");

    //Detect an error state using Search function
    let searchResult = Search(tagEntry.value);
    if (searchResult != null) {
        //Trigger Sweetalert for relevant searchResult
        swalWithDarkButton.fire({
            html: `<span class='font-weight-bolder'>${searchResult.toUpperCase()}</span>`
        });
    } else {
        //Create a new select option
        let newOption = new Option(tagEntry.value, tagEntry.value);
        document.getElementById("TagList").options[index++] = newOption;
    }

    //Clear out the TagEntry control
    tagEntry.value = "";
    return true;
}

function DeleteTag() {
    let tagCount = 1;

    let tagList = document.getElementById("TagList");
    if (!tagList) return false;

    if (tagList.selectedIndex == -1) {
        swalWithDarkButton.fire({
            html: "<span class='font-weight-bolder'>CHOOSE A TAG BEFORE DELETING</span>"
        });
        return true;
    }

    while (tagCount > 0) {
        //Get index of a selected tag from a TagList
        
        if (tagList.selectedIndex >= 0) {
            //set selected tag to null OR remove tag
            tagList.options[tagList.selectedIndex] = null;
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

//check if tagValues have data
if (tagValues != '') {
    let tagArray = tagValues.split(",");
    for (let loop = 0; loop < tagArray.length; loop++) {
        //THEN replace existing already options
        ReplaceTag(tagArray[loop], loop);
        index++;
    }
}

function ReplaceTag(tag, index) {
    let newOption = new Option(tag, tag);
    document.getElementById("TagList").options[index] = newOption;
}

//The Search fucntion detects either an empty or a duplicate Tag
//and return an error string if an error is detected
function Search(str) {
    if (str == "") {
        return 'Empty tags are not permitted';
    }

    var tagsEl = document.getElementById('TagList');
    if (tagsEl) {
        let options = tagsEl.options;
        for (let index = 0; index < options.length; index++) {
            if (options[index].value == str)
                return `The Tag #${str} was detected as a duplicate and not permitted.`;
        }
    }
}

const swalWithDarkButton = Swal.mixin({
    customClass: {
        confirmButton: 'btn btn-danger btn-sm w-100 btn-outline-dark'
    },
    imageUrl: '/img/OOPS!.jpg',
    timer: 4500,
    buttonsStyling: false
});