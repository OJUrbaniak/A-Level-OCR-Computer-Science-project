   M S B A M L   `   `   `  ����K  GcomputingProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:computingProjectcomputingProject  5   	   &     computingProject.startupCostCalc   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:computingProject     5   	     � Title$  Start-up cost calculator��5   	   $��322.666��6*   $	��294��6;    � 
ResizeMode$ CanMinimize=�6G   .��5	      � .+�5
   
   �� -   5         ��Name$ costNameBox��5
      $
��Left=�6'   $��
123,37,0,0q�6B    �� TextWrapping$
 Wrap=�6V   $	��103��6j   $��19��6v   $	��Top=�6�   �� 5   
   -   5        $ costBox��5      $��231,37,10,0q�6#   $
 Wrap=�68   $
��0.00��6L    J� RenderTransformOrigin$ 
0.777,1.39&�6X   $��19��6{   $	��Top=�6�   �� 5   
   -   5         ��Name$ 	buttonAdd��5      $	��Add��6$   $��
123,62,0,0q�62   $
��Left=�6^   $��75��6y   $��20��6�   $	��Top=�6�   �� 5   
   -   5        $ buttonRemove��5      $��Remove selected items��6'   $��203,62,10,0q�6G   $��9(�6\   $��20��6�   $	��Top=�6�   �� 5   
   -   5        $ 	resultBox��5      $��
10,266,0,0q�6%   $
 Wrap=�69   $��
Total cost��6M   $��18��6_   $	��Top=�6k   $
��Left=�6�   $	��108��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ costGrid��5      $��
10,10,0,34q�6%      AutoGenerateColumns .  $
��Left=�6U   $	��108��6p      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Name of cost��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6;   �� *Name+  5      $
	 Cost��6%   
 63   �� *Cost+5      �� 5   
   -   5        $ resultButton��5      $��Result��6'   $��Center=�68   $��123,266,0,0q�6Z   $��18��6�   $	��Top=�6�   $
��Left=�6�   $��90��6�   �� 5   
   -   5         ��Name$ label��5      $��	Cost name��6   $��
123,11,0,0q�63   $
��Bold"�6G   $��26��6Y   $	��Top=�6e   $
��Left=�6}   $	��103��6�   �� 5   
   -	   5        $ label1��5      $
��Cost��6    $
��Left=�6/   $��
231,10,0,0q�6J   $��47��6^   $
��Bold"�6i   $��26��6{   $	��Top=�6�   5      5      