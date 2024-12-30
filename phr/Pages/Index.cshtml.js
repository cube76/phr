$(document).on("click", ".open-detail", function () {
    $(".modal-body #code").val($(this).data('code'));
});

function openModal() {
	var element = document.getElementById('open-detail')
	var code = element.dataset.code; 
	var desc = element.dataset.desc; 
	var type = element.dataset.type; 

	document.querySelector('.modal-body #code') = code;

}