// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function readURL(input) {
    if (input.files && input.files[0]) {
        let reader = new FileReader();

        reader.onload = function (e) {
            $("img#imgpreview").attr("src", e.target.result).width(200).height(200);
        };

        reader.readAsDataURL(input.files[0]);
    }
}

function readURLbis(input) {
    if (input.files && input.files[0]) {
        let reader = new FileReader();

        reader.onload = function (e) {
            $("video#bandepreview").attr("src", e.target.result);
        };

        reader.readAsDataURL(input.files[0]);
    }
}


//function readURLbis(input) {
//    if (input.files && input.files[0]) {
//        let reader = new FileReader();

//        reader.onload = function (e) {
//            $("video#imgpreview").attr("src", e.target.result).width(200).height(200);
//        };

//        reader.readAsDataURL(input.files[0]);
//    }
//}

//function display(img) {

//    $ajax({
//        url: $https://localhost:44343/api/BlobExplore/item.Film_Image,
//        type: 'get',
//        success: function (response) {
//            $("#image").empty();
//            response.forEach((url) => {
//                $("#image").append("<img src='" + url + "' width='100' height='100' >");

//            })
//        }
//    });
//}

    
