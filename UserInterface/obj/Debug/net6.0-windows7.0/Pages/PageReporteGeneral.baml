   M S B A M L   `   `   `  ????T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      H DUserInterface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:UserInterface.PagesUserInterface.Pages 5      ,   &UserInterface.Pages.PageReporteGeneral   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Pcontrols;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      3local!clr-namespace:UserInterface.Pages     5      6mah,http://metro.mahapps.com/winfx/xaml/controls   5      m iMahApps.Metro.IconPacks.BootstrapIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj	 fMahApps.Metro.IconPacks.FontAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aA	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   	 5         MahApps.Styles.Page#???   5        N? Title$  PageReporte??5       N? 
Background
 ???? .??5      ? -   5         ?Name$
 Grid??5       ? ColumnDefinitions 5   
   ?? 5      ?? 5       ? RowDefinitions 5   
   ?? 5      ?? 5      ?? 5      ?? 5       ?? 5!      ?? 5"      .+?5%   
   ?? $??0??5&      $??2??5'      $??10??5(       ?? Orientation$ Vertical=?5)      .+?5*      ?? $??20(?5+      $??Center=?5,      $??Light"?5-      .??6$   Reportes Mensuales5/      ?? 51      $??0, 30, 0, 10q?52      $??20(?53      $??Center=?54      $??Light"?55      .??6$   	Contratos57      ?? 58      $ 
Horizontal=?6   $??Center=?62   .+?59      !   MahApps.Metro.Controls.Tile  $??0,0,5,0q?6   ${?False??6,   $	??180??6>   .??5:      ?? $ Vertical=?6!   $??Center=?68   .+?5;      ?? $ 
Horizontal=?6%   $??Center=?6>   .+?5<      4  .MahApps.Metro.IconPacks.PackIconBootstrapIcons  $??35??5=   !   $??35??6,   $??0,5,5,0q?69      Kind$ FileEarmark=?5>   !   
???????$??Center=?5?   !   ?? 5@      -   5         ??Name$ lb_CountTotal??5@   $   $	??130??5A       
???????$??40(?5B       $
??Left=?6.   5C      ?? 5D      $??Total??5E      
???????$??20(?5F   5   $??Center=?6C   5G      5H        5J      $??0,0,5,0q?6   ${?False??6,   $	??180??6>   .??5K      ?? $ Vertical=?6!   $??Center=?68   .+?5L      ?? $ 
Horizontal=?6%   $??Center=?6>   .+?5M        $??35??5N   !   $??35??6,   $??0,5,5,0q?69   $ ExclamationSquareFill=?5O   !   
???????$??Center=?5P   !   ?? 5Q      -   5        $ lb_CountPorCaducar??5Q   $   $??21??5R       
???????$??40(?5S       $
??Left=?6.   5T      ?? 5U      $??Por caducar??5V      
???????$??20(?5W   5   $??Center=?6C   5X      5Y        5[      $??0,0,5,0q?6   ${?False??6,   $	??180??6>   .??5\      ?? $ Vertical=?6!   $??Center=?68   .+?5]      ?? $ 
Horizontal=?6%   $??Center=?6>   .+?5^        $??35??5_   !   $??35??6,   $??0,5,5,0q?69   $ Check2Square=?5`   !   
???????$??Center=?5a   !   ?? 5b      -   5        $ lb_CountVigentes??5b   $   $??21??5c       
???????$??40(?5d       $
??Left=?6.   5e      ?? 5f      $??Vigentes??5g      
???????$??20(?5h   5   $??Center=?6C   5i      5j      5m      ?? 5o      -   5        $"??btn_GenerarReporteGeneralPDF??5q      $??	0,30,0,30q?5p      $	??200??5r      $??50??5s      .??5u      ?? $ 
Horizontal=?6   $??Center=?66   $??Center=?6S   .+?5w        $??30??5x   !   $??30??6,   $??0,5,5,0q?69   $ FileEarmarkPdf=?5y   !   
???????$??Center=?5z   !   ?? 5{      $??Center=?5|      $??15(?5}      $??Light"?5~      .??5      Generar Reporte6+   5?      5?      ?? 5?      $??20(?5?      $??	0,30,0,10q?5?      $??Center=?5?      $??Light"?5?      .??6$   Reportes por Cliente5?      &   System.Windows.Controls.DataGrid  5?      -   5          Name$ datagrid??5?      $??5q?5?      $??12(?5?      $
??Thin"?6   ???	#FFC3C3C3	   SelectionMode$	 Single=?5?      $	??500??5?      
   
IsReadOnly$

 True??5?      ??5?      ?? 5?      ?? 5?      -   5        $"??btn_GenerarReporteClientePDF??5?      $??	0,30,0,30q?5?      $	??200??5?      $??50??5?      ${?False??5?      .??5?      ?? $ 
Horizontal=?6   $??Center=?66   $??Center=?6S   .+?5?        $??30??5?   !   $??30??6,   $??0,5,5,0q?69   $ FileEarmarkPdf=?5?   !   
???????$??Center=?5?   !   ?? 5?      $??Center=?5?      $??15(?5?      $??Light"?5?      .??5?      Generar Reporte6+   5?      5?      5?      5?      5?      