$(document).ready(function(){
	$("#li1").click(function(){
		
		if($(this).hasClass("uk-open"))
		{
			$(this).removeClass("uk-open");
			$(this).children().addClass("uk-hidden");
		}
		else
		{
			$(this).addClass("uk-open");
			$(this).children().removeClass("uk-hidden");
		}
	});

})