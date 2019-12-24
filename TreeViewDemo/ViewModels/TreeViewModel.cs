using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TreeViewDemo.ViewModels.Domain;

namespace TreeViewDemo.ViewModels
{
    public class TreeViewModel : ViewModelBase
    {
        private TypeModel selectItem;

        public TypeModel SelectItem
        {
            get { return selectItem; }
            set { this.MutateVerbose(ref selectItem, value, RaisePropertyChanged()); }
        }

        public ObservableCollection<TypeTreeModel> TypeList { get; set; } = new ObservableCollection<TypeTreeModel>();
        public TreeViewModel()
        {
            TypeList = new ObservableCollection<TypeTreeModel>(GetData());
        }

        private List<TypeTreeModel> GetData()
        {
            List<TypeTreeModel> typeTrees = new List<TypeTreeModel>()
            {
                new TypeTreeModel()
                {
                    Id = 1,
                    Name = "手机",
                    ChildList = new ObservableCollection<TypeTreeModel>()
                    {
                        new TypeTreeModel(){ Id=2,Name="苹果" },
                        new TypeTreeModel(){ Id=2,Name="华为",
                            ChildList = new ObservableCollection<TypeTreeModel>()
                            {
                                new TypeTreeModel(){Id=5,Name="荣耀" }
                            }},
                        new TypeTreeModel(){ Id=2,Name="小米",
                            ChildList = new ObservableCollection<TypeTreeModel>()
                            {
                                new TypeTreeModel(){Id=5,Name="红米" }
                            }}
                    }
                },
                new TypeTreeModel()
                {
                    Id=3,
                    Name="笔记本",
                    ChildList = new ObservableCollection<TypeTreeModel>()
                    {
                        new TypeTreeModel(){Id=4,Name="联想"}
                    }
                },
                new TypeTreeModel()
                {
                    Id=3,
                    Name="耳机"
                }
            };
            return typeTrees;
        }
        public ICommand SelectItemChangeCommand
        {
            get
            {
                return new CommandBase((param) =>
                {
                    if (param != null)
                        SelectItem = (TypeModel)param;
                });
            }
        }
    }

    public class TypeTreeModel : TypeModel
    {
        public ObservableCollection<TypeTreeModel> ChildList { get; set; } = new ObservableCollection<TypeTreeModel>();
    }
    public class TypeModel : ViewModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
