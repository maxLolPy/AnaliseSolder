   M S B A M L   `   `   `  ????H  DAnaliseSolder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:AnaliseSolder.ViewsAnaliseSolder.Views  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  ?? DataType$    AnaliseSolder.Views.AttireVMwm ? ColumnDefinitions ? RowDefinitions(  "System.Windows.Controls.DatePicker   SelectedDate ?? Delay ?? UpdateSourceTrigger ?? DisplayMemberPath ?? SelectedValuePath ?? SelectedItem	 ?? SelectedValue
 ?? TextWrapping d? 	IsChecked ?? Triggers ?? Value ?? Binding ?? 
TargetName ?? Property ?? Value?? 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      +views!clr-namespace:AnaliseSolder.Views  5      %?
  (??       5      *,  +)?? 6   "    6   .R?5   
   ]? .+?5      c? $	??Top=?6   .@?5      ?? $??
Назад??6   ??6)   ?? *GoBackCommand+?? 5      $??Сохранить??6   ??6-   ?? *AttireVM.SaveItemCommand+5	      ? 5
       5      ?? 5      $
??Auto ?6'   ?? 5      $
??Auto ?6'    5      ?? 5      $
??Auto ?6$   ?? 5      $
??Auto ?6$   ?? 5      $
??Auto ?6$   ?? 5      $
??Auto ?6$   ?? 5      $
??Auto ?6$   ?? 5      $
??Auto ?6$   .+?5      ?? $??0??6   $0??*Дата проведения наряда??6)   ?? 5      $??1??6   $"??Военнослужащий??6)   ?? 5      $??2??6   $2??,Место проведения наряда??6)   ?? 5      $??3??6   $-??'Оперативный дежурный??6)   ?? 5      $??4??6   $??Замечание??6)     5      $??1??6   $??0??6-    6:   ?? *AttireVM.DateAttire+? 5      $??1??6   $??1??6'    5      ?? 5       $	??100 ?6+   ?? 5!      $??* ?6+   .+?5#      ?? ??6   ?? *SolderDescrFilter+$
 1000??$ PropertyChanged=??? 5%      $??1??6   $ DescrForFind??5&      $ SolderId??5)       5'      ?? *
SolderVM+	 5(      ?? *AttireVM.SolderId+$ PropertyChanged=???5*      ?? *SolderListVMItems+56      57      ? 58      $??1??6   $??2??6'    59      ?? 5:      $	??100 ?6+   ?? 5;      $??* ?6+   .+?5=      ?? ??6   ?? *PlaceDescrFilter+$
 1000??$ PropertyChanged=??? 5>      $??1??6   $ Descr??5?      $ PlaceId??5B       5@      ?? *	PlaceVM+	 5A      ?? *AttireVM.PlaceId+$ PropertyChanged=???5C      ?? *PlaceListVMItems+5N      5O      ? 5P      $??1??6   $??3??6'    5Q      ?? 5R      $	??100 ?6+   ?? 5S      $??* ?6+   .+?5U      ?? ??6   ?? *OficerDescrFilter+$
 1000??$ PropertyChanged=??? 5W      $??1??6   $ DescrForFind??5X      $ SolderId??5[       5Y      ?? *ResponsibleVM+	 5Z      ?? *AttireVM.ResponsibleId+$ PropertyChanged=???5\      ?? *OficerListVMItems+5g      5h      ?? 5i      $??TextBoxDescr??67   $??1??6   $??4??6*   ???#b0ffb0$

 Wrap=?6`   ??5j      ?? *AttireVM.Descr+$ PropertyChanged=??? 5k      $??1??6   $??5??6+   $3??-Положительное замечание??5l       5k   8   ?? *AttireVM.IsPositive+5l      5m      5n       5o   
   ?? 5p      $ False??6B    6   ?? *AttireVM.IsPositive+.a?5q      ?? $ TextBoxDescr??6    ? ?? ?#ffb0b06I   5r      5t      5u      