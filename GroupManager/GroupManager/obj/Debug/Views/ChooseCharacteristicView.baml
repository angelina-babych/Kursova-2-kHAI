   M S B A M L   `   `   `  ����G  CGroupManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:GroupManager.ViewsGroupManager.Views  5      1    +GroupManager.Views.ChooseCharacteristicView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:GroupManager.Views     5      ���#F0F1FF.��5	      �   � ColumnDefinitions  5
   
   �� 5      6!   �� 5      $
��1.2* �6   6.   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      $��3* �6   6*   �� 5      6   .+�5   
   ]� $��0��6   $	��200��6$   $��Right=�60   .+�5      �� -   5         ��Name$
 Back��5         TransparentButton#��[  5      $��35��5      $��35��6   $
��Left=�5       .��5      �� $'��!/Resources/Images/icons/next2.png��6   6F   5      �� 5      ���#7A8BFF  CoursesLabel#��[ 6-   $��Center=�6S   UNITUP6x   5      �� 5   
   $��	0,100,0,0q�6   $��1��6'   $��WrapWithOverflow=�67    �� TextAlignment$ Center=�6W   $	��Top=�6n   $��1��6�   $��Center=�6�   $��/Resources/Fonts/#Nunito)�6�   $��25(�6�   42Оберіть тип характеристики5      �� 5    
   -   5        $ MilitaryMode��5#        ButtonStyle#���  5       $��55��67   $��Center=�5"      $��1��5$      $
��Left=�6   $��
50,140,0,0q�69   $��1��6M   $	��200��6]   .��5%      ]� .+�5&      �� $��Center=�6   $��23(�67   $��Center=�6E   !Для військкомату6t   5'      5(      �� 5*   
   -   5        $ PromMode��5,      #���  5*      $��55��67   $��Center=�5+      $��1��5-      $��Right=�6   $��
0,140,50,0q�6:   $��1��6N   $	��200��6^   .��5.      ]� .+�5/      �� $��Center=�6   $��23(�67   $��Center=�6E   На випуск6m   50      51      56      57      