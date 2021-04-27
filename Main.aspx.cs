using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;

public partial class Main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Url.Scheme.Equals("http"))
        {
            if ((Request.Browser.Type.Contains("Safari")) || (Request.Browser.Type.Contains("InternetExplorer")))
            {
                string url = Request.Url.AbsoluteUri.Substring(7, Request.Url.AbsoluteUri.Length - 12);
                Response.Redirect("https://" + url);
            } else
            {
                string url = Request.Url.AbsoluteUri.Substring(6, Request.Url.AbsoluteUri.Length - 11);
                Response.Redirect("https://" + url);
            }
        }
       
    
        summary s5 = new summary();
        List<summary> s6 = s5.getSummaryAll();
        if (s6.Count == 1)
        {
            summary s1 = new summary();
            summary s2 = new summary();
            s2 = s1.getSummary(1);
            lblInitialSummary.Text = s2.SummaryDesc.ToString();
        }
        else if (s6.Count >= 2)
        {
            summary s1 = new summary();
            summary s2 = new summary();
            s2 = s1.getSummary(1);
            lblInitialSummary.Text = s2.SummaryDesc.ToString();

            
            summary s3 = new summary();
            summary s4 = new summary();
            int[] arraySummary =  s6.Select(x => x.SummaryID).ToArray();
            for (int i=1;i<arraySummary.Length;i++)
            {
                s4 = s3.getSummary(arraySummary[i]);
                lblLastSummary.Text += s4.SummaryDesc.ToString() + "<br/><br/>";
            }
           
        }

        education e1 = new education();
        List<education> e2 = e1.getEducationAll();
        education e3 = new education();
        education e4 = new education();
        int[] arrayEducation = e2.Select(x => x.EducationID).ToArray();
        for (int i=0;i<arrayEducation.Length;i++)
        {
            e4 = e3.getEducation(arrayEducation[i]);
            lblEducation.Text += "<div class=\"timeline-event\">\n";
            lblEducation.Text += "<div class=\"mdc-card demo-card demo-card--with-avatar timeline-content animate-card grey lighten-3\">\n";
            lblEducation.Text += "<section class=\"mdc-card__primary\">\n";
            lblEducation.Text += "<h1 class=\"mdc-card__title\" style=\"font-weight: bold; font-size: 1.15em;\">\n";
            lblEducation.Text += "<img src=\"" + "../assets/image/" + e4.EducationImage +"\" width=\"30\" height=\"30\" class=\"circle\" />&nbsp;" + e4.EducationName;
            lblEducation.Text += "\n</h1>\n<h2 class=\"black-text\" style=\"font-size: 1.05em;\">" + e4.EducationDesc + "</h2>\n";
            lblEducation.Text += "</section>\n</div>\n<div class=\"timeline-badge " + e4.EducationBadge + " white-text\">";
            lblEducation.Text += "<i class=\"material-icons\">school</i></div>\n</div>";

            lblDarkEducation.Text += "<div class=\"timeline-event white-text\">\n";
            lblDarkEducation.Text += "<div class=\"mdc-card demo-card demo-card--with-avatar timeline-content animate-card blue-grey darken-1\">\n";
            lblDarkEducation.Text += "<section class=\"mdc-card__primary\">\n";
            lblDarkEducation.Text += "<h1 class=\"mdc-card__title white-text\" style=\"font-weight: bold; font-size: 1.15em;\">\n";
            lblDarkEducation.Text += "<img src=\"" + "../assets/image/" + e4.EducationImage + "\" width=\"30\" height=\"30\" class=\"circle\" />&nbsp;" + e4.EducationName;
            lblDarkEducation.Text += "\n</h1>\n<h2 class=\"white-text\" style=\"font-size: 1.05em;\">" + e4.EducationDesc + "</h2>\n";
            lblDarkEducation.Text += "</section>\n</div>\n<div class=\"timeline-badge " + e4.EducationBadge + " white-text\">";
            lblDarkEducation.Text += "<i class=\"material-icons\">school</i></div>\n</div>";
        }

        
        cca c1 = new cca();
        List<cca> c2 = c1.getccaAll();
        cca c3 = new cca();
        cca c4 = new cca();
        int[] arrayCCA = c2.Select(x => x.ccaID).ToArray();
        for (int i=0;i<arrayCCA.Length;i++)
        {
            c4 = c3.getcca(arrayCCA[i]);
            lblCCA.Text += "<div class=\"timeline-event\">\n";
            lblCCA.Text += "<div class=\"mdc-card demo-card demo-card--with-avatar timeline-content animate-card grey lighten-3\">\n";
            lblCCA.Text += "<section class=\"mdc-card__primary\">\n";
            lblCCA.Text += "<h1 class=\"mdc-card__title\" style=\"font-weight: bold; font-size: 1.15em;\">\n";
            lblCCA.Text += "<img src=\"" + "../assets/image/" + c4.ccaImage + "\" width=\"30\" height=\"30\" class=\"circle\" />&nbsp;" + c4.ccaName;
            lblCCA.Text += "<a href=\"#\" style=\"text-decoration:none;color:black;\"><i class=\"material-icons right showLink\" id=\"" + c4.ModalID + "-show\" onclick=\"showHideContent('" + c4.ModalID + "');return false;\">info</i></a>";
            lblCCA.Text += "<a href=\"#\" style=\"text-decoration:none;color:black;display:none;\"<i class=\"material-icons right hideLink more\" id=\"" + c4.ModalID + "-hide\" onclick=\"showHideContent('" + c4.ModalID + "');return false;\">info</i></a>";
            lblCCA.Text += "\n</h1>\n";
            lblCCA.Text += "<h2 class=\"black-text\" style=\"font-size: 1.05em; \">";
            lblCCA.Text += c4.ccaDesc + "</h2>\n</section>\n";
            lblCCA.Text += "<span id=\"" + c4.ModalID + "\" class=\"more\">\n";
            lblCCA.Text += "<section class=\"mdc-card__supporting-text\">\n";
            lblCCA.Text += c4.ModalDesc + "\n</section>\n</span>\n</div>\n";
            lblCCA.Text += "<div class=\"timeline-badge " + c4.ccaBadge + " white-text\">";
            lblCCA.Text += "<i class=\"material-icons\">local_activity</i></div>\n</div>";

            lblDarkCCA.Text += "<div class=\"timeline-event\">\n";
            lblDarkCCA.Text += "<div class=\"mdc-card demo-card demo-card--with-avatar timeline-content animate-card blue-grey darken-1\">\n";
            lblDarkCCA.Text += "<section class=\"mdc-card__primary\">\n";
            lblDarkCCA.Text += "<h1 class=\"mdc-card__title white-text\" style=\"font-weight: bold; font-size: 1.15em;\">\n";
            lblDarkCCA.Text += "<img src=\"" + "../assets/image/" + c4.ccaImage + "\" width=\"30\" height=\"30\" class=\"circle\" />&nbsp;" + c4.ccaName;
            lblDarkCCA.Text += "<a href=\"#\" style=\"text-decoration:none;color:white;\"><i class=\"material-icons right showLink\" id=\"" + c4.ModalID  + arrayCCA[i] + "-show\" onclick=\"showHideContent('" + c4.ModalID + arrayCCA[i] + "');return false;\">info</i></a>";
            lblDarkCCA.Text += "<a href=\"#\" style=\"text-decoration:none;color:white;display:none;\"<i class=\"material-icons right hideLink more\" id=\"" + c4.ModalID + arrayCCA[i] + "-hide\" onclick=\"showHideContent('" + c4.ModalID + arrayCCA[i] + "');return false;\">info</i></a>";
            lblDarkCCA.Text += "\n</h1>\n";
            lblDarkCCA.Text += "<h2 class=\"white-text\" style=\"font-size: 1.05em; \">";
            lblDarkCCA.Text += c4.ccaDesc + "</h2>\n</section>\n";
            lblDarkCCA.Text += "<span id=\"" + c4.ModalID + arrayCCA[i] + "\" class=\"more\">\n";
            lblDarkCCA.Text += "<section class=\"mdc-card__supporting-text white-text\">\n";
            lblDarkCCA.Text += c4.ModalDesc + "\n</section>\n</span>\n</div>\n";
            lblDarkCCA.Text += "<div class=\"timeline-badge " + c4.ccaBadge + " white-text\">";
            lblDarkCCA.Text += "<i class=\"material-icons\">local_activity</i></div>\n</div>";
        }
       

                volunteer v1 = new volunteer();
                List<volunteer> v2 = v1.getVolunteerAll();
                volunteer v3 = new volunteer();
                volunteer v4 = new volunteer();
                int[] arrayVolunteer = v2.Select(x => x.VolunteerID).ToArray();
                for (int i=0;i<arrayVolunteer.Length;i++)
                {
                    v4 = v3.getVolunteer(arrayVolunteer[i]);
                    lblVolunteeer.Text += "<div class=\"timeline-event\">\n";
                    lblVolunteeer.Text += "<div class=\"mdc-card demo-card demo-card--with-avatar timeline-content animate-card grey lighten-3\">\n";
                    lblVolunteeer.Text += "<section class=\"mdc-card__primary\">\n";
                    lblVolunteeer.Text += "<h1 class=\"mdc-card__title\" style=\"font-weight: bold; font-size: 1.15em;\">\n";
                    lblVolunteeer.Text += "<img src=\"" + "../assets/image/" + v4.VolunteerImage + "\" width=\"30\" height=\"30\" class=\"circle\" />&nbsp;" + v4.VolunteerName;
                    lblVolunteeer.Text += "<a href=\"#\" style=\"text-decoration:none;color:black;\"><i class=\"material-icons right showLink\" id=\"" + v4.ModalID + "-show\" onclick=\"showHideContent('" + v4.ModalID + "');return false;\">info</i></a>";
                    lblVolunteeer.Text += "<a href=\"#\" style=\"text-decoration:none;color:black;display:none;\"<i class=\"material-icons right hideLink more\" id=\"" + v4.ModalID + "-hide\" onclick=\"showHideContent('" + v4.ModalID + "');return false;\">info</i></a>";
                    lblVolunteeer.Text += "\n</h1>\n";
                    lblVolunteeer.Text += "<h2 class=\"black-text\" style=\"font-size: 1.05em; \">";
                    lblVolunteeer.Text += v4.VolunteerDesc + "</h2>\n</section>\n";
                    lblVolunteeer.Text += "<span id=\"" + v4.ModalID + "\" class=\"more\">\n";
                    lblVolunteeer.Text += "<section class=\"mdc-card__supporting-text\">\n";
                    lblVolunteeer.Text += v4.ModalDesc + "\n</section>\n</span>\n</div>\n";
                    lblVolunteeer.Text += "<div class=\"timeline-badge " + v4.VolunteerBadge + " white-text\">";
                    lblVolunteeer.Text += "<i class=\"material-icons\">people</i></div>\n</div>";

                    lblDarkVolunteer.Text += "<div class=\"timeline-event\">\n";
                    lblDarkVolunteer.Text += "<div class=\"mdc-card demo-card demo-card--with-avatar timeline-content animate-card blue-grey darken-1\">\n";
                    lblDarkVolunteer.Text += "<section class=\"mdc-card__primary\">\n";
                    lblDarkVolunteer.Text += "<h1 class=\"mdc-card__title white-text\" style=\"font-weight: bold; font-size: 1.15em;\">\n";
                    lblDarkVolunteer.Text += "<img src=\"" + "../assets/image/" + v4.VolunteerImage + "\" width=\"30\" height=\"30\" class=\"circle\" />&nbsp;" + v4.VolunteerName;
                    lblDarkVolunteer.Text += "<a href=\"#\" style=\"text-decoration:none;color:white;\"><i class=\"material-icons right showLink\" id=\"" + v4.ModalID  + arrayVolunteer[i] + "-show\" onclick=\"showHideContent('" + v4.ModalID + arrayVolunteer[i] + "');return false;\">info</i></a>";
                    lblDarkVolunteer.Text += "<a href=\"#\" style=\"text-decoration:none;color:white;display:none;\"<i class=\"material-icons right hideLink more\" id=\"" + v4.ModalID + arrayVolunteer[i] + "-hide\" onclick=\"showHideContent('" + v4.ModalID + arrayVolunteer[i] + "');return false;\">info</i></a>";
                    lblDarkVolunteer.Text += "\n</h1>\n";
                    lblDarkVolunteer.Text += "<h2 class=\"white-text\" style=\"font-size: 1.05em; \">";
                    lblDarkVolunteer.Text += v4.VolunteerDesc + "</h2>\n</section>\n";
                    lblDarkVolunteer.Text += "<span id=\"" + v4.ModalID + arrayVolunteer[i] + "\" class=\"more\">\n";
                    lblDarkVolunteer.Text += "<section class=\"mdc-card__supporting-text white-text\">\n";
                    lblDarkVolunteer.Text += v4.ModalDesc + "\n</section>\n</span>\n</div>\n";
                    lblDarkVolunteer.Text += "<div class=\"timeline-badge " + v4.VolunteerBadge + " white-text\">";
                    lblDarkVolunteer.Text += "<i class=\"material-icons\">people</i></div>\n</div>";
                }
                
        job j1 = new job();
        List<job> j2 = j1.getjobAll();
        job j3 = new job();
        job j4 = new job();
        int[] arrayJob = j2.Select(x => x.JobID).ToArray();
        for (int i=0;i<arrayJob.Length;i++)
        {
            j4 = j3.getJob(arrayJob[i]);
            lblJobExperience.Text += "<div class=\"timeline-event\">\n";
            lblJobExperience.Text += "<div class=\"mdc-card demo-card demo-card--with-avatar timeline-content animate-card grey lighten-3\">\n";
            lblJobExperience.Text += "<section class=\"mdc-card__primary\">\n";
            lblJobExperience.Text += "<h1 class=\"mdc-card__title\" style=\"font-weight: bold; font-size: 1.15em;\">\n";
            lblJobExperience.Text += "<img src=\"" + "../assets/image/" + j4.JobImage + "\" width=\"30\" height=\"30\" class=\"circle\" />&nbsp;" + j4.JobName;
            lblJobExperience.Text += "<a href=\"#\" style=\"text-decoration:none;color:black;\"><i class=\"material-icons right showLink\" id=\"" + j4.ModalID + "-show\" onclick=\"showHideContent('" + j4.ModalID + "');return false;\">info</i></a>";
            lblJobExperience.Text += "<a href=\"#\" style=\"text-decoration:none;color:black;display:none;\"<i class=\"material-icons right hideLink more\" id=\"" + j4.ModalID + "-hide\" onclick=\"showHideContent('" + j4.ModalID + "');return false;\">info</i></a>";
            lblJobExperience.Text += "\n</h1>\n";
            lblJobExperience.Text += "<h2 class=\" black-text\" style=\"font-size: 1.05em; \">";
            lblJobExperience.Text += j4.JobDesc + "</h2>\n</section>\n";
            lblJobExperience.Text += "<span id=\"" + j4.ModalID + "\" class=\"more\">\n";
            lblJobExperience.Text += "<section class=\"mdc-card__supporting-text\">\n";
            lblJobExperience.Text += j4.ModalDesc + "\n</section>\n</span>\n</div>\n";
            lblJobExperience.Text += "<div class=\"timeline-badge " + j4.JobBadge + " white-text\">";
            lblJobExperience.Text += "<i class=\"material-icons\">work</i></div>\n</div>";

            lblJobExperienceDark.Text += "<div class=\"timeline-event\">\n";
            lblJobExperienceDark.Text += "<div class=\"mdc-card demo-card demo-card--with-avatar timeline-content animate-card blue-grey darken-1\">\n";
            lblJobExperienceDark.Text += "<section class=\"mdc-card__primary\">\n";
            lblJobExperienceDark.Text += "<h1 class=\"mdc-card__title white-text\" style=\"font-weight: bold; font-size: 1.15em;\">\n";
            lblJobExperienceDark.Text += "<img src=\"" + "../assets/image/" + j4.JobImage + "\" width=\"30\" height=\"30\" class=\"circle\" />&nbsp;" + j4.JobName;
            lblJobExperienceDark.Text += "<a href=\"#\" style=\"text-decoration:none;color:white;\"><i class=\"material-icons right showLink\" id=\"" + j4.ModalID + arrayJob[i] + "-show\" onclick=\"showHideContent('" + j4.ModalID + arrayJob[i] + "');return false;\">info</i></a>";
            lblJobExperienceDark.Text += "<a href=\"#\" style=\"text-decoration:none;color:white;display:none;\"<i class=\"material-icons right hideLink more\" id=\"" + j4.ModalID + arrayJob[i] + "-hide\" onclick=\"showHideContent('" + j4.ModalID + arrayJob[i] + "');return false;\">info</i></a>";
            lblJobExperienceDark.Text += "\n</h1>\n";
            lblJobExperienceDark.Text += "<h2 class=\" white-text\" style=\"font-size: 1.05em; \">";
            lblJobExperienceDark.Text += j4.JobDesc + "</h2>\n</section>\n";
            lblJobExperienceDark.Text += "<span id=\"" + j4.ModalID + arrayJob[i] + "\" class=\"more\">\n";
            lblJobExperienceDark.Text += "<section class=\"mdc-card__supporting-text white-text\">\n";
            lblJobExperienceDark.Text += j4.ModalDesc + "\n</section>\n</span>\n</div>\n";
            lblJobExperienceDark.Text += "<div class=\"timeline-badge " + j4.JobBadge + " white-text\">";
            lblJobExperienceDark.Text += "<i class=\"material-icons\">work</i></div>\n</div>";
        }

        skills skills = new skills();
        List<skills> skills2 = skills.getSkillsAll();
        skills skills3 = new skills();
        skills skills4 = new skills();
        int[] arraySkills = skills2.Select(x => x.SkillsID).ToArray();
        for (int i=0;i<arraySkills.Length;i++)
        {
            skills4 = skills3.getSkills(arraySkills[i]);
            lblSkills.Text += "\n<a class=\"tooltipped\" data-position=\"top\" data-tooltip=\"";
            lblSkills.Text += skills4.ChipName + "\">\n";
           /*truncateText*/ lblSkills.Text += "<div class=\"chip " + skills4.ChipColour + " " + skills4.TextColour + "\" style=\"font-weight: bold\">";
            lblSkills.Text += skills4.ChipName + "</div>\n</a>";
        }
        
        achievements achievement = new achievements();
        List<achievements> achievement2 = achievement.getAchievementsAll();
        achievements achievement3 = new achievements();
        achievements achievement4 = new achievements();
        int[] arrayAchievements = achievement2.Select(x => x.AchievementsID).ToArray();
        for (int i = 0; i < arrayAchievements.Length; i++)
        {
            achievement4 = achievement3.getAchievements(arrayAchievements[i]);

            lblAchievements.Text += "<div class=\"timeline-event\">\n";
            lblAchievements.Text += "<div class=\"mdc-card demo-card demo-card--with-avatar timeline-content animate-card grey lighten-3\">\n";
            lblAchievements.Text += "<section class=\"mdc-card__primary\">\n";
            lblAchievements.Text += "<h1 class=\"mdc-card__title\" style=\"font-weight: bold; font-size: 1.15em;\">\n";
            lblAchievements.Text += "<img src=\"" + "../assets/image/" + achievement4.ModalImage + "\" width=\"30\" height=\"30\" class=\"circle\" />&nbsp;" + achievement4.AchievementsName;
            lblAchievements.Text += "<a href=\"#\" style=\"text-decoration:none;color:black;\"><i class=\"material-icons right showLink\" id=\"" + achievement4.ModalID + "-show\" onclick=\"showHideContent('" + achievement4.ModalID + "');return false;\">info</i></a>";
            lblAchievements.Text += "<a href=\"#\" style=\"text-decoration:none;color:black;display:none;\"<i class=\"material-icons right hideLink more\" id=\"" + achievement4.ModalID + "-hide\" onclick=\"showHideContent('" + achievement4.ModalID + "');return false;\">info</i></a>";
            lblAchievements.Text += "\n</h1>\n";
            lblAchievements.Text += "</section>\n";
            lblAchievements.Text += "<span id=\"" + achievement4.ModalID + "\" class=\"more\">\n";
            lblAchievements.Text += "<section class=\"mdc-card__supporting-text\">\n";
            lblAchievements.Text += achievement4.ModalDesc + "\n</section>\n</span>\n</div>\n";
            lblAchievements.Text += "<div class=\"timeline-badge grey white-text\">";
            lblAchievements.Text += "<i class=\"material-icons\">work</i></div>\n</div>";

            lblAchievementsDark.Text += "<div class=\"timeline-event\">\n";
            lblAchievementsDark.Text += "<div class=\"mdc-card demo-card demo-card--with-avatar timeline-content animate-card blue-grey darken-1\">\n";
            lblAchievementsDark.Text += "<section class=\"mdc-card__primary\">\n";
            lblAchievementsDark.Text += "<h1 class=\"mdc-card__title white-text\" style=\"font-weight: bold; font-size: 1.15em;\">\n";
            lblAchievementsDark.Text += "<img src=\"" + "../assets/image/" + achievement4.ModalImage + "\" width=\"30\" height=\"30\" class=\"circle\" />&nbsp;" + achievement4.AchievementsName;
            lblAchievementsDark.Text += "<a href=\"#\" style=\"text-decoration:none;color:white;\"><i class=\"material-icons right showLink\" id=\"" + achievement4.ModalID + arrayAchievements[i] + "-show\" onclick=\"showHideContent('" + achievement4.ModalID + arrayAchievements[i] + "');return false;\">info</i></a>";
            lblAchievementsDark.Text += "<a href=\"#\" style=\"text-decoration:none;color:white;display:none;\"<i class=\"material-icons right hideLink more\" id=\"" + achievement4.ModalID + arrayAchievements[i] + "-hide\" onclick=\"showHideContent('" + achievement4.ModalID + arrayAchievements[i] + "');return false;\">info</i></a>";
            lblAchievementsDark.Text += "\n</h1>\n";
            lblAchievementsDark.Text += "</section>\n";
            lblAchievementsDark.Text += "<span id=\"" + achievement4.ModalID + arrayAchievements[i] + "\" class=\"more\">\n";
            lblAchievementsDark.Text += "<section class=\"mdc-card__supporting-text white-text\">\n";
            lblAchievementsDark.Text += achievement4.ModalDesc + "\n</section>\n</span>\n</div>\n";
            lblAchievementsDark.Text += "<div class=\"timeline-badge grey white-text\">";
            lblAchievementsDark.Text += "<i class=\"material-icons\">work</i></div>\n</div>";
        }
        
        projects project = new projects();
        List<projects> project2 = project.getProjectsAll();
        projects project3 = new projects();
        projects project4 = new projects();
        int[] arrayProjects = project2.Select(x => x.ProjectsID).ToArray();
        for (int i=0;i<arrayProjects.Length;i++)
        {
            project4 = project3.getProjects(arrayProjects[i]);

            lblProjects.Text += "<div class=\"timeline-event\">\n";
            lblProjects.Text += "<div class=\"mdc-card demo-card demo-card--with-avatar timeline-content animate-card grey lighten-3\" style=\"background: linear-gradient(-90deg," + project4.FirstColour + "," + project4.SecondColour + ");\">\n";
            lblProjects.Text += "<section class=\"mdc-card__primary\">\n";
            lblProjects.Text += "<h1 class=\"mdc-card__title\" style=\"font-weight: bold; font-size: 1.15em;\">\n";
            lblProjects.Text += "<img src=\"" + "../assets/image/" + project4.ModalImage + "\" width=\"30\" height=\"30\" class=\"circle\" />&nbsp;" + project4.ProjectsName;
            lblProjects.Text += "<a href=\"#\" style=\"text-decoration:none;color:black;\"><i class=\"material-icons right showLink\" id=\"" + project4.ModalID + "-show\" onclick=\"showHideContent('" + project4.ModalID + "');return false;\">info</i></a>";
            lblProjects.Text += "<a href=\"#\" style=\"text-decoration:none;color:black;display:none;\"<i class=\"material-icons right hideLink more\" id=\"" + project4.ModalID + "-hide\" onclick=\"showHideContent('" + project4.ModalID + "');return false;\">info</i></a>";
            lblProjects.Text += "\n</h1>\n";
            lblProjects.Text += "</section>\n";
            lblProjects.Text += "<span id=\"" + project4.ModalID + "\" class=\"more\">\n";
            lblProjects.Text += "<section class=\"mdc-card__supporting-text\">\n";
            lblProjects.Text += project4.ModalDesc + "\n</section>\n</span>\n</div>\n";
            lblProjects.Text += "<div class=\"timeline-badge grey white-text\">";
            lblProjects.Text += "</div>\n</div>";

            lblProjectsDark.Text += "<div class=\"timeline-event\">\n";
            lblProjectsDark.Text += "<div class=\"mdc-card demo-card demo-card--with-avatar timeline-content animate-card blue-grey darken-1\" style=\"background: linear-gradient(-90deg," + project4.FirstColour + "," + project4.SecondColour + ");\">\n";
            lblProjectsDark.Text += "<section class=\"mdc-card__primary\">\n";
            lblProjectsDark.Text += "<h1 class=\"mdc-card__title black-text\" style=\"font-weight: bold; font-size: 1.15em;\">\n";
            lblProjectsDark.Text += "<img src=\"" + "../assets/image/" + project4.ModalImage + "\" width=\"30\" height=\"30\" class=\"circle\" />&nbsp;" + project4.ProjectsName;
            lblProjectsDark.Text += "<a href=\"#\" style=\"text-decoration:none;color:black;\"><i class=\"material-icons right showLink\" id=\"" + project4.ModalID + arrayProjects[i] + "-show\" onclick=\"showHideContent('" + project4.ModalID + arrayProjects[i] + "');return false;\">info</i></a>";
            lblProjectsDark.Text += "<a href=\"#\" style=\"text-decoration:none;color:black;display:none;\"<i class=\"material-icons right hideLink more\" id=\"" + project4.ModalID + arrayProjects[i] + "-hide\" onclick=\"showHideContent('" + project4.ModalID + arrayProjects[i] + "');return false;\">info</i></a>";
            lblProjectsDark.Text += "\n</h1>\n";
            lblProjectsDark.Text += "</section>\n";
            lblProjectsDark.Text += "<span id=\"" + project4.ModalID + arrayProjects[i] + "\" class=\"more\">\n";
            lblProjectsDark.Text += "<section class=\"mdc-card__supporting-text black-text\">\n";
            lblProjectsDark.Text += project4.ModalDesc + "\n</section>\n</span>\n</div>\n";
            lblProjectsDark.Text += "<div class=\"timeline-badge grey black-text\">";
            lblProjectsDark.Text += "</div>\n</div>";
        }

        
    }
    
    
}