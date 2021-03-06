﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="workspace.aspx.cs" Inherits="BME513project.workspace" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta name="description" content=""/>
    <meta name="author" content="Dashboard"/>
    <meta name="keyword" content="Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina"/>

    <title>SENSE LAB WORKSPACE</title>

    <!--AngularJs files-->
    <script src="Scripts/angular.min.js"></script>
    <script src="Scripts/angular-resource.min.js"></script>
    <script src="Scripts/angular-route.min.js"></script>

    <!--Module files-->
    <script src="module/login.js"></script>

    <!-- Bootstrap core CSS -->
    <link href="assets/css/bootstrap.css" rel="stylesheet"/>

    <!--external css-->
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="assets/css/zabuto_calendar.css"/>
    <link rel="stylesheet" type="text/css" href="assets/js/gritter/css/jquery.gritter.css" />
    <link rel="stylesheet" type="text/css" href="assets/lineicons/style.css"/>

    <!-- Custom styles for this template -->
    <link href="assets/css/style.css" rel="stylesheet"/>
    <link href="assets/css/style-responsive.css" rel="stylesheet"/>

    <script src="assets/js/chart-master/Chart.js"></script>
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>

</head>

<body ng-app="loginApp" ng-controller="mainCrl">
    <form runat="server" method="post" enctype="multipart/form-data" id="formUpload">
    <div id="login_page" runat="server" visible="true">
        <div class="container">
            

            <div class="form-login" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <h2 class="form-login-heading">sign In to Upload</h2>
                <div class="login-wrap">
                    <input id="tb_ID" runat="server" type="text" class="form-control" placeholder="User ID" autofocus/>
                    <br>
                    <input id="tb_Pass"  runat="server" type="password" class="form-control" placeholder="Password"/>
                    <label class="checkbox">
                        <span class="pull-right">
                            <a data-toggle="modal" href="login.html#myModal"> Forgot Password?</a> -
                            <span style="color:red;">{{result[0].result}}</span>
                        </span>
                    </label>
                    <a  runat="server" class="btn btn-theme btn-block" onserverclick="perform_Login"><i class="fa fa-lock"></i> SIGN IN</a>
                    <hr>

                    <div class="login-social-link centered">
                        <p>or you can sign in via your social network</p>
                        <button class="btn btn-facebook"><i class="fa fa-facebook"></i> Facebook</button>
                        <button class="btn btn-twitter"><i class="fa fa-twitter"></i> Twitter</button>
                    </div>
                    <div class="registration">
                        Don't have an account yet?<br />
                        <a class="" href="#">
                            Create an account
                        </a>
                    </div>

                </div>

                <!-- Modal -->
                <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="nenden" class="modal fade" runat="server" visible="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title">Forgot Password ?</h4>
                            </div>
                            <div class="modal-body">
                                <p>Enter your e-mail address below to reset your password.</p>
                                <input type="text" name="email" placeholder="Email" autocomplete="off" class="form-control placeholder-no-fix">

                            </div>
                            <div class="modal-footer">
                                <button data-dismiss="modal" class="btn btn-default" type="button">Cancel</button>
                                <button class="btn btn-theme" type="button">Submit</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- modal -->

            </div>

        </div>
    </div>
    <section id="main_page" runat="server" visible="false" style="background-color:rgb(242,242,242);">
        <!-- **********************************************************************************************************************************************************
        TOP BAR CONTENT & NOTIFICATIONS
        *********************************************************************************************************************************************************** -->
        <!--header start-->
        <header class="header black-bg">
            <div class="sidebar-toggle-box">
                <div class="fa fa-bars tooltips" data-placement="right" data-original-title="Toggle Navigation"></div>
            </div>
            <!--logo start-->
            <a href="index.html" class="logo"><b>WORKSPACE ver1.0</b></a>
            <!--logo end-->
            <div class="nav notify-row" id="top_menu">
                <!--  notification start -->
                <ul class="nav top-menu">
                    <!-- settings start -->
                    <li class="dropdown">
                        <a data-toggle="dropdown" class="dropdown-toggle" href="">
                            <i class="fa fa-tasks"></i>
                            <span class="badge bg-theme">{{projectNum}}</span>
                        </a>
                        <ul class="dropdown-menu extended tasks-bar">
                            <div class="notify-arrow notify-arrow-green"></div>
                            <li>
                                <p class="green">You have 4 pending tasks</p>
                            </li>
                            <li>
                                <a href="index.html#">
                                    <div class="task-info">
                                        <div class="desc">DashGum Admin Panel</div>
                                        <div class="percent">40%</div>
                                    </div>
                                    <div class="progress progress-striped">
                                        <div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 40%">
                                            <span class="sr-only">40% Complete (success)</span>
                                        </div>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="index.html#">
                                    <div class="task-info">
                                        <div class="desc">Database Update</div>
                                        <div class="percent">60%</div>
                                    </div>
                                    <div class="progress progress-striped">
                                        <div class="progress-bar progress-bar-warning" role="progressbar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style="width: 60%">
                                            <span class="sr-only">60% Complete (warning)</span>
                                        </div>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="index.html#">
                                    <div class="task-info">
                                        <div class="desc">Product Development</div>
                                        <div class="percent">80%</div>
                                    </div>
                                    <div class="progress progress-striped">
                                        <div class="progress-bar progress-bar-info" role="progressbar" aria-valuenow="80" aria-valuemin="0" aria-valuemax="100" style="width: 80%">
                                            <span class="sr-only">80% Complete</span>
                                        </div>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="index.html#">
                                    <div class="task-info">
                                        <div class="desc">Payments Sent</div>
                                        <div class="percent">70%</div>
                                    </div>
                                    <div class="progress progress-striped">
                                        <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="70" aria-valuemin="0" aria-valuemax="100" style="width: 70%">
                                            <span class="sr-only">70% Complete (Important)</span>
                                        </div>
                                    </div>
                                </a>
                            </li>
                            <li class="external">
                                <a href="#">See All Tasks</a>
                            </li>
                        </ul>
                    </li>
                    <!-- settings end -->
                    <!-- inbox dropdown start-->
                    <li id="header_inbox_bar" class="dropdown">
                        <a data-toggle="dropdown" class="dropdown-toggle" href="">
                            <i class="fa fa-bullhorn"></i>
                            <span class="badge bg-theme">{{announceNum}}</span>
                        </a>
                        <ul class="dropdown-menu extended inbox">
                            <div class="notify-arrow notify-arrow-green"></div>
                            <li>
                                <p class="green">There are {{announceNum}} new announcements</p>
                            </li>
                            <li ng-repeat="a in announces">
                                <a href="index.html#">
                                    <span class="photo"><img alt="avatar" src="{{a.ava}}"></span>
                                    <span class="subject">
                                        <span class="from">{{a.authorname}}</span>
                                        <span class="time">{{a.date}}</span>
                                    </span>
                                    <span class="message">
                                        {{a.title}}
                                    </span>
                                </a>
                            </li>
                            <li>
                                <a href="index.html#">
                                    <span class="photo"><img alt="avatar" src="assets/img/ui-divya.jpg"></span>
                                    <span class="subject">
                                        <span class="from">Divya Manian</span>
                                        <span class="time">40 mins.</span>
                                    </span>
                                    <span class="message">
                                        Hi, I need your help with this.
                                    </span>
                                </a>
                            </li>
                            <li>
                                <a href="index.html#">
                                    <span class="photo"><img alt="avatar" src="assets/img/ui-danro.jpg"></span>
                                    <span class="subject">
                                        <span class="from">Dan Rogers</span>
                                        <span class="time">2 hrs.</span>
                                    </span>
                                    <span class="message">
                                        Love your new Dashboard.
                                    </span>
                                </a>
                            </li>
                            <li>
                                <a href="index.html#">
                                    <span class="photo"><img alt="avatar" src="assets/img/ui-sherman.jpg"></span>
                                    <span class="subject">
                                        <span class="from">Dj Sherman</span>
                                        <span class="time">4 hrs.</span>
                                    </span>
                                    <span class="message">
                                        Please, answer asap.
                                    </span>
                                </a>
                            </li>
                            <li>
                                <a href="index.html#">See all messages</a>
                            </li>
                        </ul>
                    </li>
                    <!-- inbox dropdown end -->
                </ul>
                <!--  notification end -->
            </div>
            <div class="top-menu">
                <ul class="nav pull-right top-menu">
                    <li><a class="logout" ng-click="perform_Logout()" style="cursor:pointer;">Log out</a></li>
                </ul>
            </div>
        </header>
        <!--header end-->
        <!-- **********************************************************************************************************************************************************
        MAIN SIDEBAR MENU
        *********************************************************************************************************************************************************** -->
        <!--sidebar start-->
        <aside>
            <div id="sidebar" class="nav-collapse ">
                <!-- sidebar menu start-->
                <ul class="sidebar-menu" id="nav-accordion">

                    <p class="centered"><a href="profile.html"><img id="imgAVA" runat="server" class="img-circle" width="60"></a></p>
                    <h5 id="txtName" runat="server" class="centered" style="color: white"></h5>
                    <label class="centered" style="color: white;width:100%;display:inline-block;text-align:center;" id="txtID" ng-model="textID" runat="server" ng-init="textID='aVal'"></label>

                    <li class="mt">
                        <a class="active" href="" id="nav_upload">
                            <i class="fa fa-dashboard"></i>
                            <span style="font-size: 13px;">Upload files</span>
                        </a>
                    </li>


                    

                </ul>
                <!-- sidebar menu end-->
            </div>
        </aside>
        <!--sidebar end-->
        <!-- **********************************************************************************************************************************************************
        MAIN CONTENT
        *********************************************************************************************************************************************************** -->





        <!--main content start-->
        <section id="main-content">
            <section class="wrapper">

                <div class="row" id="panel_upload" style="display:inline-block;">
            
                    <div class="col-lg-9 main-chart">
                        <h3 style="width: 90%; display: inline-block; text-align:center; margin-left:5%;margin-top: 0px;font-size:28px;line-height:38px;margin-top:10px;"> UPLOAD FILES AND ARTICLES </h3>
                        <h5 style="width: 100%; display: inline-block; text-align:center;"> Hi there, this is the place where you can upload your files and articles</h5>
              
                

                        <div class="row mt" style="margin-top: -20px; margin-bottom: 40px;">



                    <div class="row mt">
                        <h4 style="width: 92%; margin-left: 4%; color: #424242; display:inline-block;">ALL OF YOUR UPLOADS:</h4>
                        <div style="width: 92%; margin-left: 4%; display: inline-block; border: 1px solid #424242;">
                            <div class="content-panel">
                                <table class="table table-striped table-advance table-hover">
                                    <thead>
                                        <tr>
                                            <th><i class="fa fa-user" style="margin-left:4px; margin-right:4px;"></i>  From</th>
                                            <th class="hidden-phone"><i class="fa fa-paperclip" style="margin-right:4px;"></i>  File name</th>
                                            <th><i class="fa fa-bookmark" style="margin-right:4px;"></i>  Upload Date</th>
                                            <th><i class=" fa fa-edit" style="margin-right:4px;"></i>  Status</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr ng-repeat="u in selectedUploads">
                                            <td><a href="basic_table.html#" style="margin-left:4px; color: black;">{{u.authorname}}</a></td>
                                            <td class="hidden-phone"><b>{{u.filename}}</b></td>
                                            <td style="font-size: 14px;">{{u.date}}</td>
                                            <td><span class="label label-info label-mini">{{u.status}}</span></td>
                                            <td>
                                                <a href="{{u.link}}"><button class="btn btn-success btn-xs" style="padding: 3px; padding-right: 8px; padding-left: 6px;"><i class="fa fa-chevron-down" style="margin-right: 2px;"></i> Download</button></a>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div><!-- /content-panel -->
                        </div><!-- /col-md-12 -->
                    </div><!-- /row -->

                </div><!-- /row -->

                        <div class="row mt" style="margin-top: -10px; margin-bottom: 40px;">


                    
                    <div class="row mt" style="margin-top:-20px;">
                        <button id="btnCreateNewUpload" type="button" class="btn btn-primary" style="display:inline-block;float:right;margin-right:5%;margin-bottom:10px;padding-top:10px;padding-bottom:10px;"><i class="fa fa-plus" style="margin-right:4px;"></i> Create New Upload</button>
                        <div style="width: 92%; margin-left: 4%; display: none; border: 1px solid #424242;">
                            <div class="content-panel">
                                
                                <!-- BASIC FORM ELELEMNTS -->
                                <div class="row mt">
                                    <div class="col-lg-12">
                                        <div class="form-panel" style="border:none;box-shadow:none;">
                                            <div class="form-horizontal style-form" >
                                                <div class="form-group">
                                                    <label class="col-sm-2 col-sm-2 control-label" style="color:#424242;font-size:18px;font-weight:bold;width:80%;display:inline-block;">UPLOAD FILE FORM FORMAT</label>                                                    
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-sm-2 col-sm-2 control-label" style="color:#424242;font-size:14px;font-weight:bold;">FILE TITLE</label>
                                                    <div class="col-sm-10">
                                                        <input type="text" class="form-control" id="tbFileName" runat="server">
                                                        <span class="help-block">What should we call your file? - (Please less than 100 characters)</span>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-lg-2 col-sm-2 control-label" style="color:#424242;">ATTACHMENT</label>
                                                    <div class="col-lg-10">
                                                        <p class="form-control-static">
                                                            
                                                            <asp:FileUpload ID="FileUpload1" runat="server" Width="348px" Height="27px" />
                                                            &nbsp;
                                                            
                                                            &nbsp;<br />
                                                            <br />
      
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload1" Display="None" ErrorMessage="Your file could not be uploaded. Please try again"></asp:RequiredFieldValidator>
                    
                                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

                                                        </p>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-sm-2 col-sm-2 control-label" style="color:#424242;">PROJECT'S ID</label>
                                                    <div class="col-sm-10">
                                                        <input type="text" class="form-control" id="tbProjectID" runat="server">
                                                        <span class="help-block">Specify which project this upload belongs to</span>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-sm-2 col-sm-2 control-label" style="color:#424242;">DATE</label>
                                                    <div class="col-sm-10">
                                                        <input id="tbDate" runat="server" type="text" class="form-control round-form" value="{{getDatetime | date:'MM-dd-yyyy'}}">
                                                    </div>
                                                </div>
                                         
                                                <div class="form-group">
                                                    <label class="col-sm-2 col-sm-2 control-label" style="color:#424242;">AUTHOR ID</label>
                                                    <div class="col-sm-10">
                                                        <input class="form-control" id="tbAuthorID" runat="server" type="text" value="{{id}}" disabled>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-sm-2 col-sm-2 control-label" style="color:#424242;">DESCRIPTION</label>
                                                    <div class="col-sm-10">
                                                        <input id="tbDes" runat="server" type="text" class="form-control" placeholder="This description is optional. You can leave it blank..."/>
                                                    </div>
                                                </div>
                                                
                                                
                                                
                                                <div class="form-group">
                                                    <label class="col-lg-2 col-sm-2 control-label" style="color:#424242;">STATUS</label>
                                                    <div class="col-lg-10">
                                                        <p class="form-control-static">
                                                            <asp:Label runat="server" ID="lbStatus">Accessible</asp:Label>
                                                        </p>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <a class="btn btn-primary btn-lg btn-block" style="width:60%;margin-left:20%;" runat="server" onserverclick="btnUpload_Click"><i class="fa fa-cloud-upload" style="margin-right:8px;"></i> Upload now</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div><!-- col-lg-12-->
                                </div><!-- /row -->


                            </div><!-- /content-panel -->
                        </div><!-- /col-md-12 -->
                    </div><!-- /row -->

                </div><!-- /row -->


                    </div><!-- /col-lg-9 END SECTION MIDDLE -->
                    <!-- **********************************************************************************************************************************************************
                    RIGHT SIDEBAR CONTENT
                    *********************************************************************************************************************************************************** -->

                    <div class="col-lg-3 ds" style="border-left: 1px solid #424242;border-bottom: 1px solid #424242;">
                        <!--COMPLETED ACTIONS DONUTS CHART-->
                        <h3>RECENTLY UPLOADED</h3>

                        <!-- First Action -->
                        <div class="desc" ng-repeat="n in uploads">
                    <a style="cursor:pointer;">
                        <div class="thumb">
                            <span class="badge bg-theme"><i class="fa fa-clock-o"></i></span>
                        </div>
                        <div class="details">
                            <p>
                                <a href="{{n.link}}" style="color: black; font-size: 14px;"><b><i>{{n.filename}}</i></b></a><br />
                                <span style="color:#424242">Uploaded by: </span><a href="{{n.link}}" style="font-size: 12px;">{{n.authorname}}</a><br />
                            </p>
                        </div>
                    </a>
                </div>


                        <!-- USERS ONLINE SECTION -->
                        <h3>TEAM MEMBERS</h3>
                        <!-- First Member -->
                        <div class="desc" ng-repeat="m in users">
                    <div class="thumb">
                        <img class="img-circle" src="{{m.ava}}" width="35px" height="35px" align="">
                    </div>
                    <div class="details">
                        <p>
                            <a href="#/profiles/{{m.link}}">{{m.fullname}}</a><br />
                            <muted>{{m.type}}</muted>
                        </p>
                    </div>
                </div>


                    </div><!-- /col-lg-3 -->
            
                </div><! --/row -->

                


            </section>
        </section>


        <!--main content end-->
        <!--footer start-->
        <footer class="site-footer">
            <div class="text-center">
                @2016 SENSE LAB
                <a href="index.html#" class="go-top">
                    <i class="fa fa-angle-up"></i>
                </a>
            </div>
        </footer>
        <!--footer end-->
    </section>

    <!-- js placed at the end of the document so the pages load faster -->
    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/jquery-1.8.3.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script class="include" type="text/javascript" src="assets/js/jquery.dcjqaccordion.2.7.js"></script>
    <script src="assets/js/jquery.scrollTo.min.js"></script>
    <script src="assets/js/jquery.nicescroll.js" type="text/javascript"></script>
    <script src="assets/js/jquery.sparkline.js"></script>
    <script src="assets/js/fancybox/jquery.fancybox.js"></script>
    <script src="js/jquery/upload.js"></script>


    <!--common script for all pages-->
    <script src="assets/js/common-scripts.js"></script>

    <script type="text/javascript" src="assets/js/gritter/js/jquery.gritter.js"></script>
    <script type="text/javascript" src="assets/js/gritter-conf.js"></script>

    <!--script for this page-->
    <script src="assets/js/sparkline-chart.js"></script>
    <script src="assets/js/zabuto_calendar.js"></script>
    <!--script for this page-->
    <script src="assets/js/jquery-ui-1.9.2.custom.min.js"></script>

	<!--custom switch-->
	<script src="assets/js/bootstrap-switch.js"></script>
	
	<!--custom tagsinput-->
	<script src="assets/js/jquery.tagsinput.js"></script>
	
	<!--custom checkbox & radio-->
	
	<script type="text/javascript" src="assets/js/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
	<script type="text/javascript" src="assets/js/bootstrap-daterangepicker/date.js"></script>
	<script type="text/javascript" src="assets/js/bootstrap-daterangepicker/daterangepicker.js"></script>
	
	<script type="text/javascript" src="assets/js/bootstrap-inputmask/bootstrap-inputmask.min.js"></script>
	
	
	<script src="assets/js/form-component.js"></script>    

    <!--BACKSTRETCH-->
    <!-- You can use an image of whatever size. This script will stretch to fit in any screen size.-->
    <script type="text/javascript" src="assets/js/jquery.backstretch.min.js"></script>
    <script>
        $.backstretch("assets/img/login-bg.jpg", {speed: 500});
    </script>
    <script>
      //custom select box

      $(function(){
          $('select.styled').customSelect();
      });

    </script>
        </form>
</body>
</html>
