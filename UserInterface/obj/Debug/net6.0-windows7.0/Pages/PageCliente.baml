   M S B A M L   `   `   `  ????T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      H DUserInterface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:UserInterface.PagesUserInterface.Pages 5      %   UserInterface.Pages.PageCliente   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Pcontrols;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      3local!clr-namespace:UserInterface.Pages     5      6mah,http://metro.mahapps.com/winfx/xaml/controls   5      m iMahApps.Metro.IconPacks.BootstrapIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj	 fMahApps.Metro.IconPacks.FontAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aA	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   	 5         MahApps.Styles.Page#???   5        N? Title$  PageUsuario??5       N? 
Background
 ???? .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $??45 ?6   ?? 5       ? RowDefinitions 5   
   ?? 5      $??45 ?6   ?? 5      .+?5"   
   ?? $??0??5#      $??0??6   $??2??6*   $??5,0,0,0q?5$      $	??300??6   $
??Left=?6*   $??30(?5%      ???	#FFC3C3C3$
??Thin"?62   .??6D   
Clientes5&      ?? 5*   
    ?? Orientation$ 
Horizontal=?6   $??Right=?6/   $??1??5+      $??0??6   $??0,0,0,0q?6*   .+?5-      ?? -   5         ??Name$ 
tbx_search??5.      $	??400??5/      $??40??6   $??0,5,0,0q?50      $??18(?6"   .??51   1   52      !   MahApps.Metro.Controls.Tile  54      $??40??55      $??40??6   $??5,5,5,0q?6(   .??56      4  .MahApps.Metro.IconPacks.PackIconBootstrapIcons  $??25??57      $??25??6       Kind$ Search=?58      ???	#FFC3C3C3$??Center=?59      5:      5<      ?? 5@   
   $??0??6   $??1??6%   $??0q?62   .+?5B        -   5          Name$ btn_add??5B      $??40??5D      $??40??6   $??5,5,0,0q?6)   .??5E        $??25??5F      $??25??6    $ 
PlusSquare=?5G      ???	#FFC3C3C3$??Center=?5H      5I        5K      -   5        $ 
btn_update??5K      $??40??5M      $??40??6   $??5,5,0,0q?6)   .??5N        $??25??5O      $??25??6    $ ArrowClockwise=?5P      ???	#FFC3C3C3$??Center=?5Q      5R        5T      -   5        $ btn_edit??5T      $??40??5V      $??40??6   $??5,5,0,0q?6(   ${?False??69   .??5W        $??25??5X      $??25??6    $ 
PencilFill=?5Y      ???	#FFC3C3C3$??Center=?5Z      5[      5]      ]? 5`   
   $??1??6   $??1??6$   $??0q?61   .+?5a      &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid??5c      $??1??5e      $??5q?6!   $??15(?5f      $
??Thin"?6   ???	#FFC3C3C3	   SelectionMode$	 Single=?5g      
   
IsReadOnly$

 True??5h      ??5d      ?? 5i      5j      #   MahApps.Metro.Controls.Flyout  5m   
   -   5          Name$ Flyout??5n      $??1??5o      $??1??6   $??5q?6*      Position$ Right=?5p      $
??Auto??6      IsOpen$ False??5q      ???	#FF26292B J? Opacity$	 0.8Q?5s         CloseButtonVisibility$ Hidden=?5t      .??5u      ?  5v      ?? 5w      $??45 ?6'   ?? 5x      ?? 5y      $??45 ?6'   ?? 5z      ?? 5{      $??45 ?6'    5~      ?? 5      $??45 ?6$   ?? 5?      ?? 5?      $??45 ?6$   ?? 5?      $??45 ?6$   .+?5?      ?? $??1??6   $??1??6-   $ Vertical=?6:   $??5q?6Q   $	??Top=?6\   .+?5?      ?? $??15(?6   .??6*   Rut Cliente67   ?? 5?      -   5        $ tbx_Rutcliente??5?       ?? 
IsReadOnly$
 True??66   $??15(?6H   ?? 5?      $??15(?6   .??6*   Razon Social68   ?? 5?      -   5        $ tbx_Razonsocial??5?      $
 True??67   $??15(?6I   ?? 5?      $??15(?6   .??6*   Numero de contacto6>   ?? 5?      -	   5        $ tbx_Numerocontacto??5?      $
 True??6:   $??15(?6L   6Z   5?      ?? 5?      $??3??6   $??1??6-   $ Vertical=?6:   $??5q?6Q   $	??Top=?6\   .+?5?      ?? -
   5         ??Name$ dtp_Ismoroso??5?      $??15(?65   $??Cliente moroso??6C   $??	0,10,0,10q?6\   ?? 5?      $??15(?6   .??6*   Rubro61   ?? 5?      -   5         ??Name$ cb_Rubro??5?       ?? 
IsReadOnly$
 True??61   $??15(?6C   5?      ?? 5?      $ 
Horizontal=?6   $??3??66   $??2??6F   $??5q?6S   $??Right=?6^   .+?5?        -   5        $ 
btn_accept??5?   $   $??80??5?      $??35??6$   $??5,0,0,0q?60   $
{?True??6A      Title$ Aceptar??5?         TitleFontSize$ 15Q?6)      VerticalTitleAlignment$ Center=?6<      HorizontalTitleAlignment$ Center=?6\   5?        5?      -   5        $ 
btn_cancel??5?   $   $??80??5?      $??35??6$   $??5,0,0,0q?60   $
{?True??6A   $ Cancelar??5?      $ 15Q?6*   $ Center=?6=   $ Center=?6]   5?      5?      5?      5?      5?      5?      