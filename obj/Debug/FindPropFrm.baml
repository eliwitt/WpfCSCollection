   M S B A M L   `   `   `  ����[  WSystem.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms  5      ^ ZWindowsFormsIntegration, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration 5       WpfCSCollection!   WpfCSCollection.FindPropFrm   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      Mwf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms    5      ]wfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration    5      $	��416��5      $	��332��6     � Title$  Find the objects��6   .��5      �  � RowDefinitions 5      �� 5	   
   $��25 �6   �� 5
   
   $
��Auto �6   $��25��6&   �� 5   
   $
��Auto �6   $��25��6&   �� 5   
   $
��Auto �6   $��18��6&   �� 5   
   $
��Auto �6   $��23��6&   �� 5   
   $
��Auto �6   $��15��6&    � ColumnDefinitions 5      �� 5   
   �� 5   
   .+�5      �� $��0��6   $��2��6   .+�5   
   o� -   5        $��
MenuStrip1��5      $��8.25pt(�5      $��Tahoma)�6!   $��0,0,0,0q�5      .@�5      m� -   5        $��	MenuItem1��5   $   $	��End��6   5      5      5      �� 5      -   5         ��Name$ 
lblResults��5   9   $��6.25pt(�5      $��Microsoft Sans Serif)�6   $��4��5      $��1��6   $��23��6-   $��0,0,7,0q�6M   $	��Top=�6^   �� 5      -   5        $��Label2��5    M   $��8.25pt(�5      $��Microsoft Sans Serif)�6   $��1��5      $��1��6   $��74��5       $��25��6   $��4��6'   $��Value to Find:��64   6M   �� 5!      -   5        $��Label1��5#   M   $��8.25pt(�5!      $��Microsoft Sans Serif)�6   $��1��5"      $��0��6   $��83��5#      $��25��6   $��3��6'   $��Property Name:��64   6M   �� 5$      -   5         ��Name$ txtValue��5&   (   #��Z��5$      #��Z��6?   $��8.25pt(�6t   $��Microsoft Sans Serif)�6�   $��2��5%      $��1��6   $	��183��5&      $��20��6   6(   � 5'      $��3��6   $��2��6    5(   
   �� 5)      �� 5*      �� 5+      .+�5-   
   	� -   5         	�Name$ rbtGreaterThan��5/   L   $��8.25pt(�5-      $��Microsoft Sans Serif)�6(   $��0��6J   $��0,5,0,0q�5.      $��86��5/      $��18��6   $��4��6(   $��Greater than��65   6L   	� 50   
   -   5        $ 
rbtEqualTo��52   H   $��8.25pt(�50      $��Microsoft Sans Serif)�6(   $��1��6J   $��0,5,0,0q�51      $��64��52      $��18��6   $��3��6(   $��Equal to��65   6H   	� 53   
   -	   5        $ rbtLessThan��55   I   $��8.25pt(�53      $��Microsoft Sans Serif)�6(   $��2��6J   $��0,5,0,0q�54      $��71��55      $��18��6   $��2��6(   $��	Less than��65   6I   56      �� 57      -
   5        $��Button1��59   D   $��8.25pt(�57      $��Microsoft Sans Serif)�6   $��4��58      $��0��6   $��75��59      $��23��6   $��5��6(   $
��Find��65   6S   �� 5:      -   5        $ 
txtProName��5<   )   #��Z��5:      #��Z��6?   $��8.25pt(�6t   $��Microsoft Sans Serif)�6�   $��2��5;      $��0��6   $	��183��5<      $��20��6   6)   7  1System.Windows.Forms.Integration.WindowsFormsHost  5=      $��5��6   $��2��6$   $	��199��68   $	��Top=�6E      Child. 5>   
   '   !System.Windows.Forms.DataGridView  "   System.Windows.Forms.Control   Width$	 373��6      Height$	 150��6&   	   TabIndex$	 6��63   -   5        DataGridView1��5?      5@      5A      5B      