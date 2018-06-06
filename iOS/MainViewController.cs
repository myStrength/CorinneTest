// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;

namespace CorinneTest.iOS
{
	public partial class MainViewController : UIViewController
	{
        static Random rnd = new Random();
      
        #region Randomize Ages and Size
        int GenLowAge()
        {
            int lowAge = rnd.Next(1, 17);
            return lowAge;

        }

        int GenHighAge()
        {
            int highAge = 50 + rnd.Next(1, 50);
            return highAge;
        }

        int GenNumPeople()
        {
            int numPeople = rnd.Next(1, 100);
            return numPeople;
        }
        #endregion

        public MainViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            button2.TouchUpInside += (object sender, EventArgs e) =>
            {
                updateTable();
            };

            this.TableView.RegisterNibForCellReuse(PersonTableViewCell.Nib, PersonTableViewCell.Key);
            updateTable();
        }

        void updateTable() {
            PersonDataSource.Instance.SetList(GenLowAge(), GenHighAge(), GenNumPeople());
            this.TableView.Source = new PersonSource();
            this.TableView.ReloadData();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public class PersonSource : UITableViewSource
        {
            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = tableView.DequeueReusableCell(PersonTableViewCell.Key) as PersonTableViewCell;


                // PersonTableViewCell.Key is the CellIdentifier : done 
                // dequeue a cell from the tbleview of your type : done 
                // write a public Bind() method in the tableviewcell that accepts the index and a person : done 
                // binds fields internally (not externally) : done 
                // return the cell: done 
                var person = PersonDataSource.Instance.People[indexPath.Row];
                cell.Bind(person, indexPath.Row);
                return cell;
            }

            public override nint RowsInSection(UITableView tableview, nint section) =>
                PersonDataSource.Instance.People.Count;
        }
    }
}
