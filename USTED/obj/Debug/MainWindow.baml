   M S B A M L   `   `   `  ����@  <USTED, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:USTEDUSTED  5   	       USTED.MainWindow   5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5
   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:USTED     5   	      MaterialDesignBody#���   5   	     MaterialDesignPaper#���  5   	   $��Medium"�5   	   $��14(�5   	   $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5   	     � Title$  
MainWindow��5   	   $	��470��6   $	��425��6)    � WindowStyle$
 None=�65    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�6b   .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   �� -   5        $��0��5      
������ ._�5      � .+�5      (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ PrimaryDark=�6+   .��5      �� $��Right=�6!   .+�5      �� -   5        $��30��5   !   $��30��6,   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�68   $��0q�6i   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ WindowClose=�66   5      5       5!      5"      5#      � 5%   
   $��1��6   .+�5&        $ 
PrimaryMid=�6'   .��5'      �� $!��USTD - Update Students Data��6   $��20(�6?   $
��Left=�6M   $��Bottom=�6h   $��
30 50 0 10q�6�   5(      5)      � 5+   
   $��2��6   .+�5,      ��  �� Orientation$ Vertical=�6   $��	40 20 0 0q�60   .+�5.      �� $ 
Horizontal=�6   .+�5/        $ Account=�6.   $��Bottom=�6}   $	��0 4q�6�   ��6=   �� 	 �� ElementName$	 
txtUsuario��
 �� Path$
 BorderBrush�6�   �� 50      -   5         ��Name$ 
txtUsuario��50      $	��300��62   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Usuario��6>      
IsFloating . 6g   51      �� 53      $ 
Horizontal=�6   $��0 40 0 0q�66   .+�54        $	 Key=�6.   $��Bottom=�6|   $	��0 4q�6�   ��69   �� $	 txtContrasena��$
 BorderBrush�6�   G� 55      -   5         G�Name$ txtContrasena��55   "   $	��300��69   $ Clave��6E    . 6�   56      �� 58      $��Recordar contraseña��6   $��0 30 0 0q�6:   �� 5:      -   5         " MaterialDesignRaisedDarkButton#���  5:      $��Iniciar��6R   $��Right=�6d   $��80��6�   $��	0 20 70 0q�5;      6,   #  MaterialDesignThemes.Wpf.Card  5=      $��
0 10 10 10q�6&   $��15q�6:   $ Depth4=�6G   .��5>      �� $ 
Horizontal=�6!   .+�5?      �� �� 5@      )  #MaterialDesignThemes.Wpf.DialogHost   OpenDialogCommand �� Command# Z 6(   
������� % !MaterialDesignSubheadingHyperlink#��[ 5A   :    �� CommandTarget 5@   i   �� $	 advertencia��.�5A   u   ¿Olvidaste la contraseña?6�   5B      �� 5C      $��70 0 0 0q�6$   �� 5D      # Z 6(   
�������#��[ 5E   :    5D   i   �� $	 advertencia��.�5E   u   Registrarte6�   5F      5G      5H      5I      5J        5L   
   -   5          Name$ advertencia��5L   3      IsOpen .  $��3��6H      DialogContent 5M      �� 5N      $��15q�6   $ Vertical=�6)   .+�5O      �� $,��&Solicite al departamento de tecnologia��6    �� 5P         CloseDialogCommand#��Z 6   #���  5Q      $��Aceptar��6R   $��0 10 0 0q�6d   ��5P   _   �� $	 advertencia��5Q   d   5R      5T      5V      5W      