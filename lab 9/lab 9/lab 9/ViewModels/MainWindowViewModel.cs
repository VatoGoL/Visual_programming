using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.IO;
using ReactiveUI;
using System.Reactive;
using System.Reactive.Linq;
using Avalonia.Media.Imaging;
using lab_9.Models;

namespace lab_9.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            var itemProvider = new ElementProvider();
            CarouselButtonsEnabled = false;
            SelectedImages = new ObservableCollection<ElementImage>();
            var strFolder = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
                + "\\Assets";
            Items = new ObservableCollection<Element>(itemProvider.GetItems(strFolder));
            SelectDirectory = ReactiveCommand.Create<FileElement, Unit>(
                (file) =>
                {
                    var dir = itemProvider.GetFilesNoRecursion(Path.GetDirectoryName(file.PathEl));

                    SelectedImages.Clear();
                    foreach (var item in dir)
                    {
                        SelectedImages.Add(new ElementImage((FileElement)item));
                    }
                    for (int i = 0; i < dir.Count; i++)
                    {
                        if (file.PathEl == dir[i].PathEl)
                        {
                            ChosenIndex = i;
                            break;
                        }
                    }
                    if (SelectedImages.Count > 1)
                        CarouselButtonsEnabled = true;
                    else
                        CarouselButtonsEnabled = false;
                    return Unit.Default;
                });
            GetFilePath = ReactiveCommand.Create<FileElement, Unit>(
                (file) =>
                {
                    for (int i = 0; i < SelectedImages.Count; i++)
                    {
                        if (SelectedImages[i].PathEl == file.PathEl)
                        {
                            ChosenIndex = i;
                            break;
                        }
                    }
                    return Unit.Default;
                });
            Button_Back = ReactiveCommand.Create<Unit, Unit>(
                (unit) =>
                {
                    if (ChosenIndex - 1 < 0)
                        ChosenIndex = SelectedImages.Count - 1;
                    else ChosenIndex--;
                    return unit;
                });
            Button_Next = ReactiveCommand.Create<Unit, Unit>(
                (unit) =>
                {
                    ChosenIndex = (ChosenIndex + 1) % SelectedImages.Count;
                    return unit;
                });
        }

        ObservableCollection<Element> items;
        public ObservableCollection<Element> Items
        {
            get { return items; }
            set { this.RaiseAndSetIfChanged(ref items, value); }
        }
        ObservableCollection<ElementImage> selectedImages;
        public ObservableCollection<ElementImage> SelectedImages
        {
            get { return selectedImages; }
            set { this.RaiseAndSetIfChanged(ref selectedImages, value); }
        }
        bool carouselButtonsEnabled;
        public bool CarouselButtonsEnabled
        {
            get { return carouselButtonsEnabled; }
            set { this.RaiseAndSetIfChanged(ref carouselButtonsEnabled, value); }
        }
        int chosenIndex;
        public int ChosenIndex
        {
            get { return chosenIndex; }
            set { this.RaiseAndSetIfChanged(ref chosenIndex, value); }
        }
        public ReactiveCommand<FileElement, Unit> SelectDirectory { get; }
        public ReactiveCommand<FileElement, Unit> GetFilePath { get; }
        public ReactiveCommand<Unit, Unit> Button_Back { get; }
        public ReactiveCommand<Unit, Unit> Button_Next { get; }
    }
}