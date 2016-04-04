using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Caliburn.Micro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Presentation.Framework;
using Action = System.Action;

namespace Presentation.Controls
{
	[StyleTypedProperty(Property = nameof(ButtonStyle), StyleTargetType = typeof(Button))]
	public class MultiButtonDialog : BaseMetroDialog
	{
		static MultiButtonDialog()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(MultiButtonDialog), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(MultiButtonDialog)));
		}

		public MultiButtonDialog()
		{
			GeneratedButtons = new BindableCollection<Tuple<ICommand, string>>();
		}

		public static readonly DependencyProperty GeneratedButtonsProperty = DependencyProperty.Register(
			nameof(GeneratedButtons), typeof(BindableCollection<Tuple<ICommand, string>>), typeof(MultiButtonDialog), new PropertyMetadata(default(BindableCollection<Tuple<ICommand, string>>)));

		public BindableCollection<Tuple<ICommand, string>> GeneratedButtons
		{
			get { return (BindableCollection<Tuple<ICommand, string>>)GetValue(GeneratedButtonsProperty); }
			set { SetValue(GeneratedButtonsProperty, value); }
		}

		public static readonly DependencyProperty CloseOnEscapeProperty = DependencyProperty.Register(
			nameof(CloseOnEscape), typeof (bool), typeof (MultiButtonDialog), new PropertyMetadata(default(bool)));

		public bool CloseOnEscape
		{
			get { return (bool) GetValue(CloseOnEscapeProperty); }
			set { SetValue(CloseOnEscapeProperty, value); }
		}

		public static readonly DependencyProperty DisplayTemplateProperty = DependencyProperty.Register(
			nameof(DisplayTemplate), typeof(object), typeof(MultiButtonDialog), new PropertyMetadata(default(object)));

		public object DisplayTemplate
		{
			get { return (object)GetValue(DisplayTemplateProperty); }
			set { SetValue(DisplayTemplateProperty, value); }
		}

		public static readonly DependencyProperty ButtonPanelTemplateProperty = DependencyProperty.Register(
			nameof(ButtonPanelTemplate), typeof(ItemsPanelTemplate), typeof(MultiButtonDialog), new PropertyMetadata(default(ItemsPanelTemplate)));

		public ItemsPanelTemplate ButtonPanelTemplate
		{
			get { return (ItemsPanelTemplate)GetValue(ButtonPanelTemplateProperty); }
			set { SetValue(ButtonPanelTemplateProperty, value); }
		}

		public static readonly DependencyProperty ButtonStyleProperty = DependencyProperty.Register(
			nameof(ButtonStyle), typeof(Style), typeof(MultiButtonDialog), new PropertyMetadata(default(Style)));

		public Style ButtonStyle
		{
			get { return (Style)GetValue(ButtonStyleProperty); }
			set { SetValue(ButtonStyleProperty, value); }
		}

		protected override void OnVisualParentChanged(DependencyObject oldParent)
		{
			base.OnVisualParentChanged(oldParent);
			if (oldParent != null)
			{
				GeneratedButtons.Clear();
				Application.Current.MainWindow.PreviewKeyUp -= OwningWindowOnPreviewKeyUp;
			}
			else
			{
				Application.Current.MainWindow.PreviewKeyUp += OwningWindowOnPreviewKeyUp;
			}
		}

		private void OwningWindowOnPreviewKeyUp(object sender, KeyEventArgs keyEventArgs)
		{
			if (CloseOnEscape && keyEventArgs.Key == Key.Escape)
				DialogManager.HideMetroDialogAsync(Application.Current.MainWindow as MetroWindow, this);
		}
	}

	public class MultiButtonDialogController
	{
		private readonly MultiButtonDialog _dialog;
		private readonly MetroWindow _currentWindow;

		public MultiButtonDialogController(MultiButtonDialog dialog, MetroWindow currentWindow)
		{
			_dialog = dialog;
			_currentWindow = currentWindow;
		}

		public async Task ShowAsync(bool animate = true, bool closeOnEscape = true)
		{
			var settings = new MetroDialogSettings()
			{
				AnimateShow = animate,
			};
			_dialog.CloseOnEscape = closeOnEscape;

			await _currentWindow.ShowMetroDialogAsync(_dialog, settings);
		}

		public async Task HideAsync()
		{
			await _currentWindow.HideMetroDialogAsync(_dialog);
		}

		public string Title
		{
			get { return _dialog.Title; }
			set { _dialog.Title = value; }
		}

		public void AddButton(System.Action action, string text)
		{
			_dialog.GeneratedButtons.Add(new Tuple<ICommand, string>(new RelayCommand<object>(o => action()), text));
		}
	}
}