   M S B A M L   `   `   `  ????T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      H DUserInterface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:UserInterface.PagesUserInterface.Pages 5      "   UserInterface.Pages.PagePago   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Pcontrols;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      3local!clr-namespace:UserInterface.Pages     5      6mah,http://metro.mahapps.com/winfx/xaml/controls   5      m iMahApps.Metro.IconPacks.BootstrapIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj	 fMahApps.Metro.IconPacks.FontAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aA	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   	 5         MahApps.Styles.Page#???   5        N? Title$  PageUsuario??5       N? 
Background
 ???? .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $??45 ?6   ?? 5       ? RowDefinitions 5   
   ?? 5      $??45 ?6   ?? 5      .+?5"   
   ?? $??0??5#      $??0??6   $??2??6*   $??5,0,0,0q?5$      $	??300??6   $
??Left=?6*   $??30(?5%      ???	#FFC3C3C3$
??Thin"?62   .??6D   Pagos5&      ?? 5*   
    ?? Orientation$ 
Horizontal=?6   $??Right=?6/   $??1??5+      $??0??6   $??0,0,0,0q?6*   .+?5-      ?? -   5         ??Name$ 
tbx_search??5.      $	??400??5/      $??40??6   $??0,5,0,0q?50      $??18(?6"   .??51   1   52      !   MahApps.Metro.Controls.Tile  54      $??40??55      $??40??6   $??5,5,5,0q?6(   .??56      4  .MahApps.Metro.IconPacks.PackIconBootstrapIcons  $??25??57      $??25??6       Kind$ Search=?58      ???	#FFC3C3C3$??Center=?59      5:      5<      ?? 5@   
   $??0??6   $??1??6%   $??0q?62   .+?5A        -   5          Name$ 
btn_update??5A      $??40??5C      $??40??6   $??5,5,0,0q?6)   $
{?True??6:   .??5D        $??25??5E      $??25??6    $ ArrowClockwise=?5F      ???	#FFC3C3C3$??Center=?5G      5H      5I      ]? 5L   
   $??1??6   $??1??6$   $??0q?61   .+?5M      &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid??5N      $	??Top=?5M      $??1??5P      $??5q?6!   $??15(?5Q      $
??Thin"?6   ???	#FFC3C3C3	   SelectionMode$	 Single=?5R      
   
IsReadOnly$

 True??5S      ??5O      ?? 5T      5U      5V      5W      