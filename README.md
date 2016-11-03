<!DOCTYPE html>
<html lang='en' xmlns:wb='http://open.weibo.com/wb'>
<head>
<meta content='text/html; charset=utf-8' http-equiv='Content-Type'>
<title>
typesdk_code/typesdk_client/tree/master/README.md | 
CODE
</title>
<link href="//csdnimg.cn/public/favicon-b.ico" rel="shortcut icon" type="image/vnd.microsoft.icon" />
<script src='//csdnimg.cn/pubfooter/js/tracking.js?4927260'></script>
<script src='//csdnimg.cn/rabbit/tracking-ad/main.js'></script>
<script src='//csdnimg.cn/public/common/ace/src-min-noconflict/ace.js' type='text/javascript'></script>
<link href="//csdnimg.cn/public/common/toolbar/css2016/index.css" media="screen" rel="stylesheet" type="text/css" />
<link href="/assets/application-652cbb85a3f966bb08f095133db2e7b4.css" media="screen" rel="stylesheet" type="text/css" />
<script src="/assets/application-2ec4363a9cf839e6dafa8511f4cc965c.js" type="text/javascript"></script>
<link href="/assets/feature_groups/project-928b1bc943c4d718e1b4083082e19910.css" media="screen" rel="stylesheet" type="text/css" />
<link href="/assets/editormd-cd4bbfb219708f7502f92d197d45f6a0.css" media="screen" rel="stylesheet" type="text/css" />
<link href="/assets/function/highlight/white-0ddf530f34eacbf39052abe7bf1d129d.css" media="screen" rel="stylesheet" type="text/css" />


<script src='https://code.csdn.net/open/api/js/wb.js'></script>
<script src="/assets/project_graph-85396065f17226fc8cba50bb410de142.js" type="text/javascript"></script>


<meta content="authenticity_token" name="csrf-param" />
<meta content="4bcuYHeVszgQP7MjCdd9AXS1uxis2SPg6xiQpy6HFdE=" name="csrf-token" />
</head>

<body>
<script collection_show='true' fixed='true' id='toolbar-tpl-scriptId' prod='code' skin='black' src='//csdnimg.cn/public/common/toolbar/js/html2016.js' type='text/javascript'></script>
<script>
  //<![CDATA[
    var protocol = window.location.protocol;
    document.write('<script type="text/javascript" src="' +protocol+ '//csdnimg.cn/pubfooter/js/repoAddr2.js?v=' + Math.random() + '"></'+'script>');
  //]]>
</script>
<header class='csdn-nav navbar navbar-static-top' role='banner'>
<div class='container'>
<nav class='navbar-collapse pull-left' role='navigation'>
<ul class='navbar-nav'>
<li class=''>
<a href="/explore/projects">发现</a>
</li>
<li class=''>
<a href='/openkb'>知识库</a>
</li>
<li class=''>
<a href='/group'>讨论组</a>
</li>
</ul>
</nav>
<div class='search col-xs-6'>
<form action='/search' method='get'>
<div class='input-group'>
<input accesskey='s' class='form-control input-sm new' id='s' name='search' placeholder='搜索' required='required' size='30' tabindex='1' type='text'>
<div class='input-group-btn'>
<button class='btn btn-default btn-sm' type='submit'>
<i class='fa fa-search'></i>
</button>
</div>
</div>
</form>
</div>
<div class='pull-right'>
<a href="/snippets_manage">代码笔记</a>
<a href="/dashboard/index" style="border-right: 0px; color: #69b1cc">我的项目</a>

<a data-original-title='设置' data-toggle='tooltip' href='/keys'>
<i class='fa fa-cog'></i>
</a>
</div>
</div>
</header>
<script>
  //<![CDATA[
    $('.dropdown-menu > li > a').click(function(){
      if ($(this).attr("name") == "aaa"){
        $('#search_form').attr('action', '/search');
      }else{
        $('#search_form').attr('action', '/search_project');
      }
      $('#sec_attr').text($(this).text());
    });
    function btnclick(str){
      var url = (str == "1" ? "/search" : "/search_project");
      $('#search_form').attr('action', url).submit();
    }
  //]]>
</script>
<!--[if lt IE 9]> <div class="no-ie8 alert alert-block"><h4>请注意：</h4><p>Code不支持ie8及以下版本；建议您升级到最新的ie浏览器，或者谷歌Chrome、Firefox、Safari等；如果您使用的是IE 9+，请关闭“兼容性视图”。</p></div> <![endif]-->

<!-- = render "sdev_toolshared/user_diskspace_over_limit" -->

<div class='container main_container'>
<script>
  //<![CDATA[
    function validate_show_or_not(){
        var user_id = 238227;
        var user_name =
        $.post("/users/" + user_id + "/close_ssh_key_show", {user_id: user_id});
      }
  //]]>
</script>



<div class='project_top'>
<i class='icon-c-public'></i>
<div id='project_opts_bar'>
<div class='pull-right btn-box'>
<a href="/typesdk_code/typesdk_client/fork_select" data-remote="true" data-target="#for_show_dialog" data-toggle="modal"><i class='icon-c-fork'></i>
<span class='text'>
派生
</span>
</a><a href="/typesdk_code/typesdk_client/forks" class="social-count">0</a>
<a data-method='post' data-target='#for_show_dialog' data-toggle='modal' href='javascript:void(0);' id='watch' rel='nofollow' title='关注'>
<i class='icon-c-follow'></i>
<span class='text'>关注</span>
</a>
<a class='social-count' href='/typesdk_code/typesdk_client/watchers' id='watchs_count'>
0
</a>
<a data-method='post' href='javascript:void(0)' id='star' rel='nofollow' title='称赞'>
<i class='icon-c-praise'></i>
<span class='text'>称赞</span>
</a>
<a class='social-count' href='/typesdk_code/typesdk_client/stars' id='stars_count'>
0
</a>
<a href="/typesdk_code/typesdk_client/merge_requests/new" class="btn btn-sm btn-default pro_head_btn" title="新建合并请求">合并请求</a>
<a href="/typesdk_code/typesdk_client/edit" class="btn btn-sm btn-default">项目设置</a>

</div>

</div>
<span class='project_title'>
<span class='username'>
<a href="/typesdk_code">typesdk_code</a>
/
</span>
<span class='nowrap'>
<strong>
<a href="/typesdk_code/typesdk_client">TypeSDK_Client</a>
</strong>
<span class='language_tag'>
<span>
<a href="/explore/projects?language_name=C%23" class="badge">C#</a>
</span>
<div class='dropdown'>
<table>
<tr>
<td>
C#
</td>
<td>
<div class='progress progress-danger'>
<div class='progress-bar' style='width: 85.0%'></div>
</div>
</td>
<td>
85.0%
</td>
</tr>
<tr>
<td>
html/xml
</td>
<td>
<div class='progress progress-danger'>
<div class='progress-bar' style='width: 15.0%'></div>
</div>
</td>
<td>
15.0%
</td>
</tr>
</table>
</div>
</span>
</span>
</span>
<p style='padding-top:7px;'>
</p>
<p>
TypeSDK是著名免费开源手机游戏渠道SDK统计接入框架，此项目为Unity客户端接入Demo。
</p>
<div>
<span>
<a href="/explore/projects?tag_name=SDK" class="label">SDK</a>
</span>
<span>
<a href="/explore/projects?tag_name=Unity+Demo" class="label">Unity Demo</a>
</span>
<span>
<a href="/explore/projects?tag_name=%E6%89%8B%E6%9C%BA%E6%B8%B8%E6%88%8F" class="label">手机游戏</a>
</span>
<span>
<a href="/explore/projects?tag_name=%E6%B8%A0%E9%81%93" class="label">渠道</a>
</span>
<span>
<a href="/explore/projects?tag_name=%E8%81%9A%E5%90%88SDK" class="label">聚合SDK</a>
</span>
</div>
</div>

<div aria-hidden='true' aria-labelledby='myModalLabel' class='modal fade' id='for_show_dialog' role='dialog' tabindex='-1'></div>
<ul class='project_nav'>
<li class='selected'>
<a href="/typesdk_code/typesdk_client/tree/master">代码</a>
</li>
<li>
<a href="/typesdk_code/typesdk_client/graph/master">网络图表</a>
</li>
<li class=''>
<a href="/typesdk_code/typesdk_client/merge_requests">合并请求
<span class='count'>
0
</span>
</a></li>
<li class=''>
<a href="/typesdk_code/typesdk_client/issues?closed=0">Issues
<span class='count'>
0
</span>
</a></li>
<li class=''>
<a href="/typesdk_code/typesdk_client/wikis">wiki</a>
</li>
</ul>
<script>
  //<![CDATA[
    // for _project_opts_bar
    $(document).on("click", "#watch",
      function(){
        if("true" == "true"){
          $("#for_show_dialog").html("<div class=\'modal-dialog\'>\n<div class=\'modal-content\'>\n<div class=\'modal-header\'>\n<button aria-hidden class=\'close\' data-dismiss=\'modal\' type=\'button\'>\n&times;\n<\/button>\n<h4 class=\'modal-title\'>关注项目<\/h4>\n<\/div>\n<div class=\'modal-body\'>\n<p class=\'text-center\'>\n不能关注自己的项目\n<\/p>\n<\/div>\n<\/div>\n<\/div>\n");
        }else{
          $.post("/typesdk_code/typesdk_client/watch.js")
           .success(function(data){
              if(data != "false"){
                $("#project_opts_bar").html(data);
              }else{
                //alert("关注失败！");
              }
    
           });
         }
      }
    );
    
    $(document).on("click", "#unwatch",
      function(){
        $.post("/typesdk_code/typesdk_client/unwatch.js")
         .success(function(data){
            if(data != "false"){
              $("#project_opts_bar").html(data);
            }else{
              //alert("取消关注失败！");
            }
         })
      }
    );
    
    $(document).on("click", "#star",
      function(){
        $.post("/typesdk_code/typesdk_client/star.js")
         .success(function(data){
           if(data != "false"){
             $("#project_opts_bar").html(data);
           }else{
             //alert("赞失败！");
           }
         })
      }
    );
    
    
    $(document).on("click", "#unstar",
      function(){
        $.post("/typesdk_code/typesdk_client/unstar.js")
         .success(function(data){
           if(data != "false"){
             $("#project_opts_bar").html(data);
           }else{
             //alert("取消赞失败！");
           }
         })
      }
    );
  //]]>
</script>


<div class='top_url_bar'>
<div class='row'>
<div class='col-sm-12 show-web-ide'>
<div class='left-box-width'>
<div class='input-group url_bar js-copy-box'>
<div class='input-group-btn'>
<a class='active btn btn-default url-btn' href='javascript:void()' type='SSH' url='git@code.csdn.net:typesdk_code/typesdk_client.git'>
SSH
</a>
<a class='btn btn-default url-btn' href='javascript:void()' type='HTTP' url='https://code.csdn.net/typesdk_code/typesdk_client.git'>
HTTPS
</a>
</div>
<input class='url_val js-copy-val form-control' readonly value='git@code.csdn.net:typesdk_code/typesdk_client.git'>
<div class='input-group-btn'>
<span class='btn btn-default js-copy-btn'>
<i class='icon-c-copy'></i>
<ins>拷贝地址</ins>
</span>
</div>
</div>
</div>
<div class='pad-left0'>
<div class='pull-left btn-download-box'>
<a class='btn btn-default btn_download' href='/typesdk_code/typesdk_client/repository/archive?ref=master'>
<i class='icon-c-download'></i>
下载
</a>
<span class='social-count'>3</span>
</div>
<div class='pull-right btn-web-box'>
<a class='btn btn-blue-color' href='http://c-ide.csdn.net/open/typesdk_code/typesdk_client' title='进入C-IDE'>
<i class='icon iconfont-webide icon-ide'></i>
C-IDE
</a>
</div>
</div>
</div>
</div>
</div>
<script src="/assets/function/zero_clipboard-ef4a5ac532b102cf0d3ae0e17c964ea6.js" type="text/javascript"></script>
<script>
  //<![CDATA[
    $(document).ready(function () {
      var url_to_repo = $(".url_val.js-copy-val");
    
      $(".url-btn[disabled!='disabled']").each(function(){
        var link = $(this);
        var current_url = link.attr('url');
        link.on('click', function() {
          remove_class();
          url_to_repo.val(current_url);
          $(this).addClass('active');
        });
      });
    });
    
    function remove_class(){
      $(".url-btn").each(function(){
        $(this).removeClass('active');
      });
    }
  //]]>
</script>

<div class='project_main code'>
<ul class='nav nav-tabs'>
<li>
<div class='btn-group filter-list'>
<span class='btn btn-default'>
<i class='fa fa-random'></i>
master
</span>
<a class='btn btn-default dropdown-toggle'>
<span class='caret'></span>
</a>
<ul class='dropdown-menu-active list-unstyled'>
<div class='close'>×</div>
<h4>选择分支 / 标签</h4>
<div class='search_box'>
<input class='form-control' name='q' placeholder='筛选' tabindex='1' type='text'>
</div>
<div class='tabbable'>
<ul class='nav nav-tabs list-unstyled'>
<li class='active'>
<a data-toggle='tab' href='#tabs_branch'>
分支
<i class='count'></i>
</a>
</li>
<li>
<a data-toggle='tab' href='#tabs_tags'>
标签
<i class='count'></i>
</a>
</li>
</ul>
<div class='tab-content'>
<div class='tab-pane active' id='tabs_branch'>
<ul class='filter-ul list-unstyled'>
<li>
<a href="/typesdk_code/typesdk_client/refs/switch?destination=tree&amp;path=README.md&amp;ref=master&amp;utf8=true">master</a>
</li>
</ul>
</div>
<div class='tab-pane' id='tabs_tags'>
<ul class='filter-ul list-unstyled'>
</ul>
</div>
</div>
</div>
</ul>
</div>

</li>
<li class='active'>
<a href="/typesdk_code/typesdk_client/tree/master">代码</a>
</li>
<li class=''>
<a href="/typesdk_code/typesdk_client/commits/master">提交历史</a>
</li>
<li class=''>
<a href="/typesdk_code/typesdk_client/repository/branches">分支
<span class='counter'>
1
</span>
</a></li>
<li class=''>
<a href="/typesdk_code/typesdk_client/repository/tags">项目标签
<span class='counter'>
0
</span>
</a></li>
<li class=''>
<a href="/typesdk_code/typesdk_client/releases">版本发布</a>
</li>
<li class=''>
<a href="/typesdk_code/typesdk_client/compare">比较</a>
</li>
</ul>
<div class='tab-content clearfix'>
<div class='clearfix'>
<ul class='breadcrumb pull-left'>
<li>
<a href="/typesdk_code/typesdk_client/tree/master">TypeSDK_Client
</a></li>
<li>
<a href="/typesdk_code/typesdk_client/tree/master/README.md">README.md</a>
</li>
</ul>
<p class='pull-right'>
项目最近一次提交：3 天 前
<span>
<a href="/typesdk_code/typesdk_client/commit/ca9bb2daa9d3e85ae3067acd0766e1a729059e40">ca9bb2daa</a>
</span>
</p>
</div>
<div class='pull_requst clearfix'>
<div class='box_shadow_gray author_box'>
<a href="/typesdk_code"><img alt="4_typesdk_code" class="avatar_20" src="https://code.csdn.net/avatar_csdn_net_proxy/F/C/A/4_typesdk_code.jpg" /> typesdk_code</a>
<i>
update ready
</i>
<i class='pull-right'>
2016-10-31 21:53:56
</i>
</div>
</div>
<div class='CODE_snippets'>
<h5 class='clearfix'>
<div class='pull-left'>
<span>文件</span>
<span>19行</span>
<span>950 Bytes</span>
</div>
<div class='pull-right'>
<div class='btn-group'>
<a href="/typesdk_code/typesdk_client/tree/master/README.md/edit" class="btn btn-default btn-xs"> 编辑</a>
<a href="/typesdk_code/typesdk_client/blob/master/README.md" class="btn btn-default btn-xs" target="_blank">Raw</a>
<a href="/typesdk_code/typesdk_client/blame/master/README.md" class="btn btn-default btn-xs">追溯视图</a>
<a href="/typesdk_code/typesdk_client/commits/master/README.md" class="btn btn-default btn-xs">历史</a>
</div>
</div>

</h5>
<div class='snippets_cont file_holder'>
<div class='file_content wiki'>
<div class='gollum-markdown-content'>&#x000A;<div class='markdown-body'>&#x000A;<p><h2><b>TypeSdkClient是统一渠道接入框架的Unity部分客户端，使用c#编写，已开源，CP可以免费使用，目前支持80个国内的安卓和越狱渠道。</h2></b></p>&#x000A;&#x000A;<p>该部分代码包括了演示demo和抽象层接口library</p>&#x000A;&#x000A;<p>demo主要用来演示抽象层的调用逻辑</p>&#x000A;&#x000A;<p>library为抽象层主体，直接添加进项目即可，请一定不要修改其中的U3DTypeAttName.cs中的常量定义</p>&#x000A;&#x000A;<hr>&#x000A;&#x000A;<p>接入技术交流群：592253146</p>&#x000A;&#x000A;<p>官方网站：http://www.typesdk.com</p>&#x000A;&#x000A;<p>支持渠道列表<a href="http://www.typesdk.com/#channel" rel="nofollow" target="_blank">支持列表</a></p>&#x000A;&#x000A;<p>DEMO演示地址：<a href="http://demo.typesdk.com:56789" rel="nofollow" target="_blank">演示地址</a>  （用户名和密码：demo@typesdk.com/123.com）</p>&#x000A;&#x000A;<p>需要了解更多的信息请访问官方网站</p>&#x000A;&#x000A;</div>&#x000A;</div></div>
<script>
  //<![CDATA[
    $(function(){
      $('.line_numbers').css({'width':'auto'});
    })
  //]]>
</script>

</div>
</div>



</div>
</div>
<div class='code_right_fixed'>
<div class='code_qq_group'>
<div class='close'></div>
<a href='#nogo' target='_self'>
<b></b>
<span>
CODE用户交流群<br>467722610
</span>
</a>
</div>

</div>


</div>
<div class='footer'>
<div class='container'>
<ul class='pull-left list-inline'>
<li>
<a href="/blog">博客</a>
</li>
<li>
<a href='/CSDN_Code/code_support/issues'>反馈</a>
</li>
<li>
<a href="/help">帮助</a>
</li>
</ul>
<div class='pull-right'>Copyright &copy; 2016, CSDN.NET, All Rights Reserved</div>
</div>
</div>
<script btnid='header_notice_num' count='5' id='noticeScript' src='//csdnimg.cn/rabbit/notev2/js/notify.js?4927260' subcount='5' type='text/javascript' wrapid='note1'></script>
<script btnId='header_notice_num' count='5' id='csdn-toolbar-id' src='//csdnimg.cn/public/common/toolbar/js/toolbar.js' subCount='5' type='text/javascript' wrapId='note1'></script>

</body>
</html>


