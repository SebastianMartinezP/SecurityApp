   M S B A M L   `   `   `  ????T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      H DUserInterface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:UserInterface.PagesUserInterface.Pages 5      +   %UserInterface.Pages.PagePerfilUsuario   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Pcontrols;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      3local!clr-namespace:UserInterface.Pages     5      6mah,http://metro.mahapps.com/winfx/xaml/controls   5      m iMahApps.Metro.IconPacks.BootstrapIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj	 fMahApps.Metro.IconPacks.FontAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aA	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   	 5         MahApps.Styles.Page#???   5        N? Title$  PageUsuario??5       N? 
Background
 ???? .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $??45 ?6   ?? 5       ? RowDefinitions 5   
   ?? 5      $??45 ?6   ?? 5       .+?5$   
   ?? $??0??5%      $??0??6   $??2??6*   $??5,0,0,0q?5&      $	??300??6   $
??Left=?6*   $??30(?5'      ???	#FFC3C3C3$
??Thin"?62   .??6D   Perfiles de Usuario5(      ?? 5,   
    ?? Orientation$ 
Horizontal=?6   $??Right=?6/   $??1??5-      $??0??6   $??0,0,0,0q?6*   .+?5/      ?? -   5         ??Name$ 
tbx_search??50      $	??400??51      $??40??6   $??0,5,0,0q?52      $??18(?6"   .??53   1   54      !   MahApps.Metro.Controls.Tile  56      $??40??57      $??40??6   $??5,5,5,0q?6(   .??58      4  .MahApps.Metro.IconPacks.PackIconBootstrapIcons  $??25??59      $??25??6       Kind$ Search=?5:      ???	#FFC3C3C3$??Center=?5;      5<      5>      ?? 5B   
   $??0??6   $??1??6%   $??0q?62   .+?5D        -   5          Name$ btn_add??5D      $??40??5F      $??40??6   $??5,5,0,0q?6)   .??5G        $??25??5H      $??25??6    $ 
PlusSquare=?5I      ???	#FFC3C3C3$??Center=?5J      5K        5M      -   5        $ 
btn_update??5M      $??40??5O      $??40??6   $??5,5,0,0q?6)   .??5P        $??25??5Q      $??25??6    $ ArrowClockwise=?5R      ???	#FFC3C3C3$??Center=?5S      5T        5V      -   5        $ btn_edit??5V      $??40??5X      $??40??6   $??5,5,0,0q?6(   ${?False??69   .??5Y        $??25??5Z      $??25??6    $ 
PencilFill=?5[      ???	#FFC3C3C3$??Center=?5\      5]      5_      ]? 5b   
   $??1??6   $??1??6$   $??0q?61   .+?5c      &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid??5e      $??1??5g      $??5q?6!   $??15(?5h      $
??Thin"?6   ???	#FFC3C3C3	   SelectionMode$	 Single=?5i      
   
IsReadOnly$

 True??5j      ??5f      ?? 5k      5l      #   MahApps.Metro.Controls.Flyout  5o   
   -   5          Name$ Flyout??5p      $??1??5q      $??1??6   $??5q?6*      Position$ Right=?5r      $
??Auto??6      IsOpen$ False??5s      ???	#FF26292B J? Opacity$	 0.8Q?5u         CloseButtonVisibility$ Hidden=?5v      .??5w      ?  5x      ?? 5y      $??45 ?6'   ?? 5z      ?? 5{      $??45 ?6'   ?? 5|      ?? 5}      $??45 ?6'    5?      ?? 5?      $??45 ?6$   ?? 5?      ?? 5?      $??45 ?6$   ?? 5?      $??45 ?6$   .+?5?      ?? $??1??6   $??1??6-   $ Vertical=?6:   $??5q?6Q   $	??Top=?6\   .+?5?      ?? $??15(?6   .??6*   
Idperfil64   ?? 5?      -   5        $ tbx_Idperfil??5?       ?? 
IsReadOnly$
 True??64   $??15(?6F   5?      ?? 5?      $??3??6   $??1??6-   $ Vertical=?6:   $??5q?6Q   $	??Top=?6\   .+?5?      ?? $??15(?6   .??6*   Descripcion67   ?? 5?      -   5        $ tbx_Descripcion??5?      $
 True??67   $??15(?6I   5?      ?? 5?      $ 
Horizontal=?6   $??3??66   $??2??6F   $??5q?6S   $??Right=?6^   .+?5?        -	   5        $ 
btn_accept??5?   $   $??80??5?      $??35??6$   $??5,0,0,0q?60   $
{?True??6A      Title$ Aceptar??5?         TitleFontSize$ 15Q?6)      VerticalTitleAlignment$ Center=?6<      HorizontalTitleAlignment$ Center=?6\   5?        5?      -
   5        $ 
btn_cancel??5?   $   $??80??5?      $??35??6$   $??5,0,0,0q?60   $
{?True??6A   $ Cancelar??5?      $ 15Q?6*   $ Center=?6=   $ Center=?6]   5?      5?      5?      5?      5?      5?      