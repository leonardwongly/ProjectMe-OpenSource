<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Debug="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Leonard's Portfolio</title>
    <link rel="stylesheet" href="assets/css/font-awesome.css">
    <script src="assets/js/jquery-3.1.1.min.js"></script>
    <script type="text/javascript">
        function showHide(shID) {
            if (document.getElementById(shID)) {
                if (document.getElementById(shID + '-show').style.display != 'none') {
                    document.getElementById(shID + '-show').style.display = 'none';
                    document.getElementById(shID).style.display = 'block';
                }
                else {
                    document.getElementById(shID + '-show').style.display = 'inline';
                    document.getElementById(shID).style.display = 'none';
                }
            }
        }
        function showHideContent(shID) {
            if (document.getElementById(shID)) { //More content shown
                if (document.getElementById(shID + '-show').style.display != 'none') {
                    document.getElementById(shID + '-show').style.display = 'none';
                    document.getElementById(shID).style.display = 'block';
                    document.getElementById(shID + '-hide').style.display = 'block';
                }
                else { //More content hidden
                    document.getElementById(shID + '-show').style.display = 'inline';
                    document.getElementById(shID).style.display = 'none';
                    document.getElementById(shID + '-hide').style.display = 'none';
                }
            }
        }
    </script>
    <link rel="stylesheet" type="text/css" href="assets/css/timeline.css" />
    <style type="text/css">
        .more {
            display: none;
            border-top: 1px solid #666;
            border-bottom: 1px solid #666;
        }

        a.showLink, a.hideLink {
            text-decoration: underline;
            padding-left: 8px;
        }

            a.showLink:hover, a.hideLink:hover {
                border-bottom: 1px dotted #36f;
            }

        .icons {
            width: 350px;
            display: block;
            margin: 0 auto;
        }


        .my-bordered-list {
            /* remove the side padding. we'll be placing it around the item instead. */
            padding-right: 0;
            padding-left: 0;
        }

            .my-bordered-list .mdc-list-item {
                /* Add the list side padding padding to the list item. */
                padding: 0 16px;
                /* Add a border around each element. */
                border: 1px solid rgba(0, 0, 0, .12);
            }
                /* Ensure adjacent borders don't collide with one another. */
                .my-bordered-list .mdc-list-item:not(:first-child) {
                    border-top: none;
                }

        .truncateText {
            width: 100px;
            white-space: nowrap;
            overflow: hidden;
            text-overflow: ellipsis;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        $(document).ready(function () {
            $('.scrollspy').scrollSpy();
        });
        $(document).ready(function () {
            $('.modal').modal();
        });
        
    </script>
    <script src="assets/js/material-components-web.min.js"></script>
    <script>M.AutoInit()</script>
    <script>
        var elem = document.querySelector('.tooltipped');
       // var instance = M.Tooltip.init(elem, options);
    </script>
    <script>mdc.autoInit()</script>

    <div class="container" style="margin-top: 30px">
        <div class="row">
            <div class="col s12 m12 l10">
                <div class="row">
                    <div class="row">
                        <div class="col s12 m9 l10 push-l4 push-s4 push-m4">
                            <img src="assets/image/leoo.jpeg" alt="" class="circle responsive-img cyan lighten-1 padding-2" width="150" height="150">
                        </div>
                    </div>
                    <h4 class="card-title text-darken-4 center-align">Leonard Wong</h4>
                    <h5 class="center-align" style="font-size: 1.3em;">
                        <i class="material-icons">perm_identity</i>Final Year SMU Student<br />Quantedge Foundation Scholar<br />MPA GIA 2019 Awardee
                    </h5>
                    <h5 class="center-align">
                        <i class="material-icons">location_on</i> Singapore 🇸🇬
                    </h5>
                    <p class="grey-text text-lighten-4">
                        <ul class="social-icons center-align">
                            <li><a href="https://linkedin/leothelion96" class="social-icon" target="_blank" rel="noreferrer noopener"><i class="fa fa-linkedin-square" id="linkedin" aria-hidden="true"></i></a></li>
                            <li><a href="mailto:me@leonardwong.net" class="social-icon" target="_blank" rel="noreferrer noopener"><i class="fa fa-envelope-o" id="email" aria-hidden="true"></i></a></li>
                            <li><a href="https://t.me/leothelion96" class="social-icon" target="_blank" rel="noreferrer noopener"><i class="fa fa-telegram" id="telegram" aria-hidden="true"></i></a></li>

                        </ul>
                    </p>
                </div>
                <div class="card grey darken-2 hoverable">
                    <div class="card-content white-text">
                        <div id="summaryPage" class="section scrollspy">
                            <span class="card-title center">Summary</span>
                            <p>
                                <asp:Label ID="lblInitialSummary" runat="server" CssClass="white-text"></asp:Label>
                                <a href="#" id="summary-show" class="showLink" onclick="showHide('summary');return false;">&darr;Expand</a>
                                <br />
                                <br />
                                <span id="summary" class="more">
                                    <asp:Label ID="lblLastSummary" runat="server" CssClass="white-text"></asp:Label>
                                    <a href="#" id="summary-hide" class="hideLink" onclick="showHide('summary');return false;">&uarr;Collapse</a>
                                </span>
                            </p>
                        </div>
                    </div>
                </div>
                <!----- Education ----->
                <div id="education" class="section scrollspy">
                    <h5 class="center-align">Education</h5>
                    <div class="timeline">
                        <asp:Label ID="lblEducation" runat="server"></asp:Label>
                    </div>
                </div>

                <div id="educationDark" class="section scrollspy" style="display: none;">
                    <h5 class="center-align white-text">Education</h5>
                    <div class="timeline">
                        <asp:Label ID="lblDarkEducation" runat="server"></asp:Label>
                    </div>
                </div>
                <!----- Education ----->
                <br />
                <!------ Job Experience ------>
                <div id="jobExperience" class="section scrollspy">
                    <h5 class="center-align">Job Experience</h5>

                    <div class="timeline">
                        <asp:Label ID="lblJobExperience" runat="server"></asp:Label>
                    </div>
                </div>
                <div id="jobExperienceDark" class="section scrollspy" style="display: none;">
                    <h5 class="center-align white-text">Job Experience</h5>

                    <div class="timeline">
                        <asp:Label ID="lblJobExperienceDark" runat="server"></asp:Label>
                    </div>
                </div>
                <!-- Job Experience -->
                <br />
                <!----- CCA ----->
                <div id="cca" class="section scrollspy">
                    <h5 class="center-align">Co-Curricular Activities</h5>
                    <div class="timeline">
                        <asp:Label ID="lblCCA" runat="server"></asp:Label>
                    </div>
                </div>

                <div id="ccaDark" class="section scrollspy" style="display: none">
                    <h5 class="center-align white-text">Co-Curricular Activities</h5>
                    <div class="timeline">
                        <asp:Label ID="lblDarkCCA" runat="server"></asp:Label>
                    </div>
                </div>
                <!----- CCA ----->
                <br />
                <!----- Achievements ----->
                <div id="achievements" class="section scrollspy">
                    <h5 class="center-align">Achievements</h5>
                    <div class="row">
                        <div class="col s12 m12 l12 ">
                            <div class="timeline">
                                <asp:Label ID="lblAchievements" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="achievementsDark" class="section scrollspy" style="display: none;">
                    <h5 class="center-align white-text">Achievements</h5>
                    <div class="row">
                        <div class="col s12 m12 l12">
                            <div class="timeline">
                                <asp:Label ID="lblAchievementsDark" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <!----- Achievements ----->
                <br />
                <!----- Volunteer ----->
                <div id="volunteer" class="section scrollspy">
                    <h5 class="center-align">Volunteer Experience</h5>
                    <div class="timeline">
                        <asp:Label ID="lblVolunteeer" runat="server"></asp:Label>
                    </div>
                </div>

                <div id="volunteerDark" class="section scrollspy" style="display: none;">
                    <h5 class="center-align white-text">Volunteer Experience</h5>
                    <div class="timeline">
                        <asp:Label ID="lblDarkVolunteer" runat="server"></asp:Label>
                    </div>
                </div>
                <!------ Volunteer ----->
                <br />
                <!----- Skills ----->
                <div id="skills" class="section scrollspy">
                    <div class="card blue-grey hoverable">
                        <div class="card-content white-text">
                            <span class="card-title">Skills</span>
                            <asp:Label ID="lblSkills" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
                <!---- Skills ----->
                <br />
                <!----- Projects ----->
                <div id="projects" class="section scrollspy">
                    <h5 class="center-align">Projects</h5>
                    <div class="row">
                        <div class="col s12 m12 l12">
                            <ul class="collapsible" data-collapsible="accordion">
                                <asp:Label ID="lblProjects" runat="server"></asp:Label>
                            </ul>
                        </div>
                    </div>
                </div>

                <div id="projectsDark" class="section scrollspy" style="display: none;">
                    <h5 class="center-align white-text">Projects</h5>
                    <div class="row">
                        <div class="col s12 m12 l12">
                            <ul class="collapsible" data-collapsible="accordion">
                                <asp:Label ID="lblProjectsDark" runat="server"></asp:Label>
                            </ul>
                        </div>
                    </div>
                </div>
                <!----- Projects ----->
            <div class="col l2 hide-on-med-and-down" style="position: fixed; right: 30px; top: 60px;" id="lightTableContents">
                <ul class="section table-of-contents">
                    <li><a href="#summaryPage">Summary</a></li>
                    <li><a href="#education">Education</a></li>
                    <li><a href="#jobExperience">Job Experience</a></li>
                    <li><a href="#cca">Co-Curricular Activities</a></li>
                    <li><a href="#achievements">Achievements</a></li>
                    <li><a href="#volunteer">Volunteer Experience</a></li>
                    <li><a href="#skills">Skills</a></li>
                    <li><a href="#projects">Projects</a></li>
                </ul>
            </div>
            <div class="col l2 hide-on-med-and-down" style="position: fixed; right: 30px; top: 60px; display: none;" id="darkTableContents">
                <ul class="section table-of-contents">
                    <li><a href="#summaryPage">Summary</a></li>
                    <li><a href="#educationDark">Education</a></li>
                    <li><a href="#jobExperienceDark">Job Experience</a></li>
                    <li><a href="#ccaDark">Co-Curricular Activities</a></li>
                    <li><a href="#achievementsDark">Achievements</a></li>
                    <li><a href="#volunteerDark">Volunteer Experience</a></li>
                    <li><a href="#skills">Skills</a></li>
                    <li><a href="#projectsDark">Projects</a></li>
                </ul>
            </div>
                </div>
        </div>
    </div>

    <script src="assets/js/scrollreveal.js"></script>
    <script>
        window.sr = ScrollReveal();
        sr.reveal('.animate-card', {
            origin: 'left',
            duration: 500,
            scale: 0.3,
            opacity: 0,
            easing: 'cubic-bezier(0.6, 0.2, 0.1, 1)',
            mobile: true,
            reset: true,
            viewFactor: 0.1
        });

    </script>
    <script src="assets/js/ScrollTrigger.min.js"></script>
    <script>
        $(document).ready(function () {
            $('.collapsible').collapsible();
        });
    </script>

</asp:Content>

