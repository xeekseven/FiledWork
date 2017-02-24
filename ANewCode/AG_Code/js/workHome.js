var divTop=new Vue({
	el:'#div-nav',
	template:
  `<nav class="navbar navbar-inverse navbar-fixed-top">
        <div class="container-fluid">
          <div class="navbar-header">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
              <span class="sr-only">Toggle navigation</span>
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>
            </button>
            <div>  
              <a class="navbar-brand" href="workHome.html"><img style="height: 100%;width: 11%;float: left;margin: 0 10px 0px 10px;" src="img/yancao.png">烟草分拣监控</a>
            </div>
            
          </div>
          <div id="navbar" class="navbar-collapse collapse">
            <ul class="nav navbar-nav navbar-right">
              <li><a href="#">常用功能</a></li>
              <li><a href="#">设置</a></li>
              <li><a href="#">关于</a></li>
              <li><a href="#">帮助</a></li>
            </ul>
            <form class="navbar-form navbar-right">
              <input type="text" class="form-control" placeholder="Search...">
            </form>
          </div>
        </div>
      </nav>`
});
var divContent=new Vue({
  el:'div-content',
  template:`<div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main" >
            <div class="div_notice">
              <ul class="ul_notice">
                <li><span><strong>公告:</strong></span></li>
                <li><span>&nbsp;&nbsp;--2017/2/17--</span></li>
                <li><a href="#">&nbsp;&nbsp;公告的内容 比如：今天服务器升级</a></li>

              </ul>
              <div style="float: right; margin-right: 5%">
                <a href="#">more</a>&nbsp;&nbsp;&nbsp;&nbsp;
                <a href="#"><span class="glyphicon glyphicon-triangle-top"></span></a>
              </div>
            </div>

            <div style="border: 15px solid #EDEDED;padding: 15px;">
              <h1 class="page-header">常用功能</h1>
              <div class="row placeholders">
                <div class="col-xs-6 col-sm-3 placeholder">
                  <img src="data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" width="200" height="200" class="img-responsive" alt="Generic placeholder thumbnail">
                  <h4>Label</h4>
                  <span class="text-muted">Something else</span>
                </div>
                <div class="col-xs-6 col-sm-3 placeholder">
                  <img src="data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" width="200" height="200" class="img-responsive" alt="Generic placeholder thumbnail">
                  <h4>Label</h4>
                  <span class="text-muted">Something else</span>
                </div>
                <div class="col-xs-6 col-sm-3 placeholder">
                  <img src="data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" width="200" height="200" class="img-responsive" alt="Generic placeholder thumbnail">
                  <h4>Label</h4>
                  <span class="text-muted">Something else</span>
                </div>
                <div class="col-xs-6 col-sm-3 placeholder">
                  <img src="data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" width="200" height="200" class="img-responsive" alt="Generic placeholder thumbnail">
                  <h4>Label</h4>
                  <span class="text-muted">Something else</span>
                </div>
              </div>

              <h2 class="sub-header">Section title</h2>
              <div class="table-responsive">
                <table class="table table-striped">
                  <thead>
                    <tr>
                      <th>#</th>
                      <th>Header</th>
                      <th>Header</th>
                      <th>Header</th>
                      <th>Header</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <td>1,001</td>
                      <td>Lorem</td>
                      <td>ipsum</td>
                      <td>dolor</td>
                      <td>sit</td>
                    </tr>
                    <tr>
                      <td>1,002</td>
                      <td>amet</td>
                      <td>consectetur</td>
                      <td>adipiscing</td>
                      <td>elit</td>
                    </tr>
                    <tr>
                      <td>1,003</td>
                      <td>Integer</td>
                      <td>nec</td>
                      <td>odio</td>
                      <td>Praesent</td>
                    </tr>
                    <tr>
                      <td>1,003</td>
                      <td>libero</td>
                      <td>Sed</td>
                      <td>cursus</td>
                      <td>ante</td>
                    </tr>
                    <tr>
                      <td>1,004</td>
                      <td>dapibus</td>
                      <td>diam</td>
                      <td>Sed</td>
                      <td>nisi</td>
                    </tr>
                    <tr>
                      <td>1,005</td>
                      <td>Nulla</td>
                      <td>quis</td>
                      <td>sem</td>
                      <td>at</td>
                    </tr>
                    <tr>
                      <td>1,006</td>
                      <td>nibh</td>
                      <td>elementum</td>
                      <td>imperdiet</td>
                      <td>Duis</td>
                    </tr>
                    <tr>
                      <td>1,007</td>
                      <td>sagittis</td>
                      <td>ipsum</td>
                      <td>Praesent</td>
                      <td>mauris</td>
                    </tr>
                    <tr>
                      <td>1,008</td>
                      <td>Fusce</td>
                      <td>nec</td>
                      <td>tellus</td>
                      <td>sed</td>
                    </tr>
                    <tr>
                      <td>1,009</td>
                      <td>augue</td>
                      <td>semper</td>
                      <td>porta</td>
                      <td>Mauris</td>
                    </tr>
                    <tr>
                      <td>1,010</td>
                      <td>massa</td>
                      <td>Vestibulum</td>
                      <td>lacinia</td>
                      <td>arcu</td>
                    </tr>
                    <tr>
                      <td>1,011</td>
                      <td>eget</td>
                      <td>nulla</td>
                      <td>Class</td>
                      <td>aptent</td>
                    </tr>
                    <tr>
                      <td>1,012</td>
                      <td>taciti</td>
                      <td>sociosqu</td>
                      <td>ad</td>
                      <td>litora</td>
                    </tr>
                    <tr>
                      <td>1,013</td>
                      <td>torquent</td>
                      <td>per</td>
                      <td>conubia</td>
                      <td>nostra</td>
                    </tr>
                    <tr>
                      <td>1,014</td>
                      <td>per</td>
                      <td>inceptos</td>
                      <td>himenaeos</td>
                      <td>Curabitur</td>
                    </tr>
                    <tr>
                      <td>1,015</td>
                      <td>sodales</td>
                      <td>ligula</td>
                      <td>in</td>
                      <td>libero</td>
                    </tr>
                  </tbody>
                </table>
              </div>
            </div>
          </div>`
});
var divLeft=new Vue({
	el:'div-left',
	template:
	`<div id="div_op_left" class="col-sm-3 col-md-2 sidebar ">
            <ul id="ul_suofang" class="nav nav-sidebar nav-noMargin">
              <li class="icon"><a style="padding-left: 45%" href="#"><span class="glyphicon glyphicon-th-list" aria-hidden="true"></span></a>
              </li>
            </ul>
            <ul id="zs_ul_1" class="nav nav-sidebar nav-noMargin" >
              <li class="success" ><a  href="#"><span id="sp_fenj" class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                &nbsp;&nbsp;分拣操作</a>
              </li>
            </ul>
            <ul id="ul_plc_op" style="display: none;"  class="nav nav-sidebar">
              <li>
                <a href="#">
                  <span class="glyphicon glyphicon-eye-open" aria-hidden="true"></span>
                  &nbsp;&nbsp;整体监控 
                  <span class="sr-only">(current)</span>
                </a>
              </li>
              <li>
                <a href="#">
                  <span class="glyphicon glyphicon-book" aria-hidden="true" ></span>
                  &nbsp;&nbsp;输出日志
                </a>
              </li>
              <li><a href="#">Analytics</a></li>
              <li><a href="#">Export</a></li>
            </ul>
            <ul id="zs_ul_2" class="nav nav-sidebar nav-noMargin">
              <li  class="success"><a  href="#"><span id="sp_query" class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                &nbsp;&nbsp;统计查询</a>
              </li>
            </ul>
            <ul id="ul_query_op" style="display: none;"  class="nav nav-sidebar">
              <li>
                <a href="query.html">
                  <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
                  &nbsp;&nbsp;烟仓盘点查询
                  <span class="sr-only">(current)</span>
                </a>
              </li>
              <li>
                <a href="#">
                  <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true" ></span>
                  &nbsp;&nbsp;故障查询
                </a>
              </li>
              <li>
                <a href="#">
                  <span class="glyphicon glyphicon-random" aria-hidden="true"></span>
                  &nbsp;&nbsp;批次效率记录
                </a>
              </li>
              <li>
                <a href="#">
                  <span class="glyphicon glyphicon-object-align-left" aria-hidden="true"></span>
                  &nbsp;&nbsp;补货信息查询
                </a>
              </li>
            </ul>
            <ul class="nav nav-sidebar">
              <li><a href="">Nav item</a></li>
              <li><a href="">Nav item again</a></li>
              <li><a href="">One more nav</a></li>
              <li><a href="">Another nav item</a></li>
              <li><a href="">More navigation</a></li>
            </ul>
            
   </div>`
})