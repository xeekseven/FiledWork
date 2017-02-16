$(document).ready(function(){
	$("ul#zs_ul_1").click(function(){
		$("ul#ul_plc_op").is(":hidden")
		? ($("ul#ul_plc_op").show(),$("span#sp_fenj").toggleClass("glyphicon glyphicon-chevron-right"),$("span#sp_fenj").toggleClass("glyphicon glyphicon-chevron-down"))
		: ($("ul#ul_plc_op").hide(),$("span#sp_fenj").toggleClass("glyphicon glyphicon-chevron-down"),$("span#sp_fenj").toggleClass("glyphicon glyphicon-chevron-right"));
	});
	$("ul#zs_ul_2").click(function(){
		$("ul#ul_query_op").is(":hidden")
		? ($("ul#ul_query_op").show(),$("span#sp_query").toggleClass("glyphicon glyphicon-chevron-right"),$("span#sp_query").toggleClass("glyphicon glyphicon-chevron-down"))
		: ($("ul#ul_query_op").hide(),$("span#sp_query").toggleClass("glyphicon glyphicon-chevron-down"),$("span#sp_query").toggleClass("glyphicon glyphicon-chevron-right"));
	});
	$("li").click(function(){
		$("li").removeClass("active");
		$(this).toggleClass("active");
	});
})