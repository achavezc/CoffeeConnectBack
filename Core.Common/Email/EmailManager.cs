using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
namespace WebGYM.Common
{
    public class EmailManager
    {

        public bool SendEmailBienvenida(string path,string asunto, string nombre, string correo, string usuario, string clave,string url,string from,string logo)
        {
           

            var html = File.ReadAllText(path);//File.ReadAllText("~/plantillas_correo/bienvenida.html");
           
             string cuerpo = html.Replace("{nombre}", nombre);
             string cuerpo2 = cuerpo.Replace("{usuario}", usuario);
             string cuerpo3 = cuerpo2.Replace("{clave}", clave);
             string cuerpo4 = cuerpo3.Replace("{url}", url);
             string cuerpo5= cuerpo4.Replace("{logo}", url + logo);


            return enviarCorreo(correo, asunto, cuerpo5, from);
            
        }



        public bool SendEmailRecuperarPassword(string nombre,string password, string correo, string from)
        {

            string html = @"<p>&nbsp;</p>
<!-- [if (mso 16)]>
    <style type='text/css'>
    a {text-decoration: none;}
    </style>
    <![endif]-->
<p></p>
<!-- [if gte mso 9]><style>sup { font-size: 100% !important; }</style><![endif]-->
<div class='es-wrapper-color' style='background-color: #f6f6f6;'><!-- [if gte mso 9]>
			<v:background xmlns:v='urn:schemas-microsoft-com:vml' fill='t'>
				<v:fill type='tile' color='#f6f6f6'></v:fill>
			</v:background>
		<![endif]-->
<table class='es-wrapper' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px; padding: 0; margin: 0; width: 100%; height: 100%; background-repeat: repeat; background-position: center top;' width='100%' cellspacing='0' cellpadding='0'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0;' valign='top'>
<table class='es-header' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px; table-layout: fixed !important; width: 100%; background-color: transparent; background-repeat: repeat; background-position: center top;' cellspacing='0' cellpadding='0' align='center'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0;' align='center'>
<table class='es-header-body' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px; background-color: #464646;' width='600' cellspacing='0' cellpadding='0' align='center' bgcolor='#ffffff'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0;' align='left'><!-- [if mso]><table width='600' cellpadding='0' cellspacing='0'><tr><td width='191' valign='top'><![endif]-->
<table class='es-left' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px; float: left;' cellspacing='0' cellpadding='0' align='left'>
<tbody>
<tr style='border-collapse: collapse;'>
<td class='es-m-p0r' style='padding: 0; margin: 0;' align='center' valign='top' width='191'>
<table style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px;' width='100%' cellspacing='0' cellpadding='0'>
<tbody>
<tr style='border-collapse: collapse;'>
<td class='es-m-p0l' style='padding: 0; margin: 0; padding-bottom: 5px;' align='left'><img style='display: block; border: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic;' title='Sunrise logo' src='https://beequeencoin.com/assets/images/emails/bienvenida/logo.png' alt='BEE QUEEN COIN' width='108' /></td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<!-- [if mso]></td><td width='20'></td><td width='389' valign='top'><![endif]-->
<table style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px;' cellspacing='0' cellpadding='0' align='right'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0;' align='left' width='389'>
<table style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px;' width='100%' cellpadding='0'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0;'>
<table class='es-menu' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px;' width='100%' cellspacing='0' cellpadding='0'>
<tbody>
<tr class='links' style='border-collapse: collapse;'>
<td id='esd-menu-id-0' style='margin: 0; border: 0; padding: 25px 5px 25px 5px;' align='center' bgcolor='transparent' width='25%'><a style='-webkit-text-size-adjust: none; -ms-text-size-adjust: none; mso-line-height-rule: exactly; font-family: Arial, sans-serif; font-size: 14px; text-decoration: none; display: block; color: #a5a29b;' href='https://beequeencoin.com/home'>Proyectos</a></td>
<td id='esd-menu-id-1' style='margin: 0; border: 0; padding: 25px 5px 25px 5px;' align='center' bgcolor='transparent' width='25%'><a style='-webkit-text-size-adjust: none; -ms-text-size-adjust: none; mso-line-height-rule: exactly; font-family: Arial, sans-serif; font-size: 14px; text-decoration: none; display: block; color: #a5a29b;' href='https://beequeencoin.com/session/signin'>Login</a></td>
<td id='esd-menu-id-2' style='margin: 0; border: 0; padding: 25px 5px 25px 5px;' align='center' bgcolor='transparent' width='25%'><a style='-webkit-text-size-adjust: none; -ms-text-size-adjust: none; mso-line-height-rule: exactly; font-family: Arial, sans-serif; font-size: 14px; text-decoration: none; display: block; color: #a5a29b;' href='https://beequeencoin.com/about'>Nosotros</a></td>
<td id='esd-menu-id-3' style='margin: 0; border: 0; padding: 25px 5px 25px 5px;' align='center' bgcolor='transparent' width='25%'><a style='-webkit-text-size-adjust: none; -ms-text-size-adjust: none; mso-line-height-rule: exactly; font-family: Arial, sans-serif; font-size: 14px; text-decoration: none; display: block; color: #a5a29b;' href='https://beequeencoin.com/contact'>Cont&aacute;ctanos</a></td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<!-- [if mso]></td></tr></table><![endif]--></td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<table class='es-content' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px; table-layout: fixed !important; width: 100%;' cellspacing='0' cellpadding='0' align='center'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0;' align='center'>
<table class='es-content-body' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px; background-color: #ffffff;' width='600' cellspacing='0' cellpadding='0' align='center'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0;' align='left'>
<table style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px;' width='100%' cellspacing='0' cellpadding='0'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0;' align='center' valign='top' width='600'>
<table style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px;' width='100%' cellspacing='0' cellpadding='0'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0;' align='center'><img class='adapt-img' style='display: block; border: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic;' title='Bienvenido' src='https://beequeencoin.com/assets/images/emails/bienvenida/banner.jpeg' alt='Bienvenido' width='600' /></td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0; background-color: #ffffff;' align='left' bgcolor='#ffffff'>
<table style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px;' width='100%' cellspacing='0' cellpadding='0'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0;' align='center' valign='top' width='600'>
<table style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px;' width='100%' cellspacing='0' cellpadding='0'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0; padding-bottom: 10px; padding-top: 25px;' align='center'>
<h2 style='margin: 0; line-height: 29px; mso-line-height-rule: exactly; font-family: Arial, sans-serif; font-size: 24px; font-style: normal; font-weight: normal; color: #333333;'>HOLA {nombre}!</h2>
</td>
</tr>
<tr style='border-collapse: collapse;'>
<td style='margin: 0; padding: 5px 15px 15px 15px;' align='center'>
<p style='margin: 0; -webkit-text-size-adjust: none; -ms-text-size-adjust: none; mso-line-height-rule: exactly; font-size: 14px; font-family: Arial, sans-serif; line-height: 21px; color: #333333;'>Has solicitado recuperar tu clave de acceso a Beequeencoin.com.</p>
<p style='margin: 0; -webkit-text-size-adjust: none; -ms-text-size-adjust: none; mso-line-height-rule: exactly; font-size: 14px; font-family: Arial, sans-serif; line-height: 21px; color: #333333;'>Tu clave es: {clave}</p>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<table class='es-content' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px; table-layout: fixed !important; width: 100%;' cellspacing='0' cellpadding='0' align='center'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0;' align='center'>
<table class='es-content-body' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px; background-color: #ffffff;' width='600' cellspacing='0' cellpadding='0' align='center' bgcolor='#31cb4b'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='margin: 0; background-color: #ffffff; padding: 15px 15px 20px 15px;' align='left' bgcolor='#ffffff'><br /><!-- [if mso]></td></tr></table><![endif]--></td>
</tr>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0;' align='left'>
<table style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px;' width='100%' cellspacing='0' cellpadding='0'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0;' align='center' valign='top' width='580'>
<table style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px;' width='100%' cellspacing='0' cellpadding='0'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0;' align='center'>
<table style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px;' border='0' width='100%' cellspacing='0' cellpadding='0'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0px; border-bottom: 1px solid #CCCCCC; background: none; height: 1px; width: 100%;'>&nbsp;</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<table class='es-content' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px; table-layout: fixed !important; width: 100%;' cellspacing='0' cellpadding='0' align='center'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0;' align='center'>
<table class='es-footer-body' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px; background-color: #464646;' width='600' cellspacing='0' cellpadding='0' align='center'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='margin: 0; padding: 25px 20px 25px 20px;' align='left'><!-- [if mso]><table width='560' cellpadding='0' cellspacing='0'><tr><td width='194'><![endif]-->
<table class='es-left' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px; float: left;' cellspacing='0' cellpadding='0' align='left'>
<tbody>
<tr style='border-collapse: collapse;'>
<td class='es-m-p0r es-m-p20b' style='padding: 0; margin: 0;' align='center' width='174'>
<table style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px;' width='100%' cellspacing='0' cellpadding='0'>
<tbody>
<tr style='border-collapse: collapse;'>
<td class='es-m-txt-с' style='padding: 0; margin: 0; padding-bottom: 10px;' align='left'>
<h4 style='margin: 0; line-height: 120%; mso-line-height-rule: exactly; font-family: Arial, sans-serif; color: #fec903;'>Cont&aacute;ctanos</h4>
</td>
</tr>
<tr style='border-collapse: collapse;'>
<td class='es-m-txt-с' style='padding: 0; margin: 0;' align='left'>
<p style='margin: 0; -webkit-text-size-adjust: none; -ms-text-size-adjust: none; mso-line-height-rule: exactly; font-size: 14px; font-family: Arial, sans-serif; line-height: 21px; color: #a5a29b;'>+51 954828488</p>
<p style='margin: 0; -webkit-text-size-adjust: none; -ms-text-size-adjust: none; mso-line-height-rule: exactly; font-size: 14px; font-family: Arial, sans-serif; line-height: 21px; color: #a5a29b;'>contacto@beequeencoin.com</p>
</td>
</tr>
</tbody>
</table>
</td>
<td class='es-hidden' style='padding: 0; margin: 0;' width='20'>&nbsp;</td>
</tr>
</tbody>
</table>
<!-- [if mso]></td><td width='173'><![endif]-->
<table class='es-left' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px; float: left;' cellspacing='0' cellpadding='0' align='left'>
<tbody>
<tr style='border-collapse: collapse;'>
<td class='es-m-p0r es-m-p20b' style='padding: 0; margin: 0;' align='center' width='173'>
<table style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px;' width='100%' cellspacing='0' cellpadding='0'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0; padding-bottom: 10px;' align='left'>
<h4 style='margin: 0; line-height: 120%; mso-line-height-rule: exactly; font-family: Arial, sans-serif; color: #fec903;'>&nbsp;</h4>
</td>
</tr>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0;' align='left'>
<p style='margin: 0; -webkit-text-size-adjust: none; -ms-text-size-adjust: none; mso-line-height-rule: exactly; font-size: 14px; font-family: Arial, sans-serif; line-height: 21px; color: #a5a29b;'><br /><br /></p>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<!-- [if mso]></td><td width='20'></td><td width='173'><![endif]-->
<table class='es-right' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px; float: right;' cellspacing='0' cellpadding='0' align='right'>
<tbody>
<tr style='border-collapse: collapse;'>
<td class='es-m-p0r es-m-p20b' style='padding: 0; margin: 0;' align='center' width='173'>
<table style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px;' width='100%' cellspacing='0' cellpadding='0'>
<tbody>
<tr style='border-collapse: collapse;'>
<td class='es-m-txt-с' style='padding: 0; margin: 0; padding-bottom: 10px;' align='left'>
<h4 style='margin: 0; line-height: 120%; mso-line-height-rule: exactly; font-family: Arial, sans-serif; color: #fec903;'>Social networks</h4>
</td>
</tr>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0;' align='left'>
<table class='es-table-not-adapt es-social' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px;' cellspacing='0' cellpadding='0'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0; padding-right: 10px;' align='center' valign='top'><a style='-webkit-text-size-adjust: none; -ms-text-size-adjust: none; mso-line-height-rule: exactly; font-family: Arial, sans-serif; font-size: 14px; text-decoration: underline; color: #a5a29b;' href='https://www.facebook.com/beequeencoin/'><img style='display: block; border: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic;' title='Facebook' src='https://beequeencoin.com/assets/images/emails/bienvenida/facebook-circle-white.png' alt='Fb' width='32' height='32' /></a></td>
<td style='padding: 0; margin: 0; padding-right: 10px;' align='center' valign='top'><a style='-webkit-text-size-adjust: none; -ms-text-size-adjust: none; mso-line-height-rule: exactly; font-family: Arial, sans-serif; font-size: 14px; text-decoration: underline; color: #a5a29b;' href='https://www.youtube.com/'><img style='display: block; border: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic;' title='Youtube' src='https://beequeencoin.com/assets/images/emails/bienvenida/youtube-circle-white.png' alt='Yt' width='32' height='32' /></a></td>
<td style='padding: 0; margin: 0;' align='center' valign='top'><a style='-webkit-text-size-adjust: none; -ms-text-size-adjust: none; mso-line-height-rule: exactly; font-family: Arial, sans-serif; font-size: 14px; text-decoration: underline; color: #a5a29b;' href='https://www.instagram.com/beequeencoin' target='_blank' rel='noopener'><img style='display: block; border: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic;' title='Instagram' src='https://beequeencoin.com/assets/images/emails/bienvenida/instagram-circle-white.png' alt='Ig' width='32' height='32' /></a></td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<!-- [if mso]></td></tr></table><![endif]--></td>
</tr>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0;' align='left'>
<table style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px;' width='100%' cellspacing='0' cellpadding='0'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0;' align='center' valign='top' width='580'>
<table style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px;' width='100%' cellspacing='0' cellpadding='0'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0;' align='center'>
<table style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px;' border='0' width='100%' cellspacing='0' cellpadding='0'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0px; border-bottom: 1px solid #CCCCCC; background: none; height: 1px; width: 100%;'>&nbsp;</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
<tr style='border-collapse: collapse;'>
<td style='margin: 0; padding: 15px 20px 15px 20px;' align='left'><!-- [if mso]><table width='560' cellpadding='0' cellspacing='0'><tr><td width='270' valign='top'><![endif]-->
<table class='es-left' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px; float: left;' cellspacing='0' cellpadding='0' align='left'>
<tbody>
<tr style='border-collapse: collapse;'>
<td class='es-m-p20b' style='padding: 0; margin: 0;' align='left' width='270'>
<table style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px;' width='100%' cellspacing='0' cellpadding='0'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0; display: none;' align='center'>&nbsp;</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<!-- [if mso]></td><td width='20'></td><td width='270' valign='top'><![endif]-->
<table class='es-right' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px; float: right;' cellspacing='0' cellpadding='0' align='right'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0;' align='left' width='270'>
<table style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px;' width='100%' cellspacing='0' cellpadding='0'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0; display: none;' align='center'>&nbsp;</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<!-- [if mso]></td></tr></table><![endif]--></td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<table class='es-content' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px; table-layout: fixed !important; width: 100%;' cellspacing='0' cellpadding='0' align='center'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0;' align='center'>
<table class='es-content-body' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px; background-color: transparent;' width='600' cellspacing='0' cellpadding='0' align='center'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='margin: 0; padding: 30px 20px 30px 20px;' align='left'>
<table style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px;' width='100%' cellspacing='0' cellpadding='0'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0;' align='center' valign='top' width='560'>
<table style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse; border-spacing: 0px;' width='100%' cellspacing='0' cellpadding='0'>
<tbody>
<tr style='border-collapse: collapse;'>
<td style='padding: 0; margin: 0; display: none;' align='center'>&nbsp;</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
</div>";
            string cuerpo = html.Replace("{nombre}", nombre.ToUpper());
            cuerpo = cuerpo.Replace("{clave}", password);
            //MailMessage msg = new MailMessage();

            //msg.From = new MailAddress("santiagoruiz1912@gmail.com");
            //msg.To.Add(correo);
            //msg.Subject = "Bienvenido a BEE QUEEN COIN!";

            //msg.IsBodyHtml = true;
            //

            //msg.Body = cuerpo;
            ////msg.Priority = MailPriority.High;

            //try
            //{
            //    using (SmtpClient client = new SmtpClient())
            //    {
            //        client.EnableSsl = true;
            //        client.UseDefaultCredentials = false;
            //        client.Credentials = new System.Net.NetworkCredential("santiagoruiz1912@gmail.com", "anavero281");
            //        client.Host = "smtp.gmail.com";
            //        client.Port = 587;
            //        client.DeliveryMethod = SmtpDeliveryMethod.Network;

            //        client.Send(msg);
            //        return true;
            //    }


            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}


            return enviarCorreo(correo, "Recuperación de contraseña BEE QUEEN COIN", cuerpo, from);

        }

 

        private bool enviarCorreo(string correo, string asunto, string cuerpo, string from,  string fileAttachments = "", string fileAttachments2 = "")
        {
            
            MailMessage m = new MailMessage();

            if (fileAttachments!= String.Empty)
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(fileAttachments);
                m.Attachments.Add(attachment);
            }

            if (fileAttachments2 != String.Empty)
            {
                System.Net.Mail.Attachment attachment2;
                attachment2 = new System.Net.Mail.Attachment(fileAttachments2);
                m.Attachments.Add(attachment2);
            }

            SmtpClient sc = new SmtpClient();
            m.From = new MailAddress(from);
            //m.Bcc.Add("manuel@beequeencoin.com");
            //m.Bcc.Add("postmaster@beequeencoin.com");
            m.To.Add(correo);
            m.Subject = asunto;
            m.IsBodyHtml = true;
            m.Body = cuerpo;
          
            sc.Host = "mail.beequeencoin.com";
          

            try
            {
                sc.Port = 25;
                sc.Credentials = new System.Net.NetworkCredential("postmaster@beequeencoin.com", "p@ssw0rd");
                sc.EnableSsl = false;
                sc.Send(m);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        

    }
}
