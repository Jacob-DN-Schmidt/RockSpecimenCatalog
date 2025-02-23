using System.Data;
using System.Windows.Forms;

namespace LibrarySystem324.Model {
    internal class Specimen {
        private readonly DataRow _Row;
        public Specimen (DataRow aRow) {
            int id = (int) aRow["id"];
            DataTable dt = DBEngine.GetTable("Select * From specimen where ID=" + id.ToString());

            _Row = dt.Rows[0];
        }


        public static DataTable Search (string filter) {
            string SQL = "select * from specimen ";
            if (filter.Trim() != "") {
                SQL += "where " + filter.Trim();
            }
            DataTable tbl = DBEngine.GetTable(SQL);
            return tbl;
        }
        public static DataTable GetTable () {
            return DBEngine.GetTable("select * from specimen");
        }
        public static DataTable GetTableWithClassification () {
            return DBEngine.GetTable("select s.ID as ID, s.CommonName as 'Common Name', s.color as 'Color', s.form as 'Form', s.weight as 'Weight', s.origin as 'Origin', concat_ws(', ', group_concat(sc.gemstonename separator ', '), group_concat(sc.metalname separator ', '), group_concat(sc.rockname separator ', '), group_concat(sc.mineralname separator ', ')) as Classifications from specimen s left join specimenclass sc on sc.SpecimenID = s.id group by s.ID;");
        }
        public static void CreateNew () {//
            string SQL = "INSERT INTO Specimen (CommonName, Color, Form, Weight, Origin) VALUES('', '', '', '', '')";
            DBEngine.Execute(SQL);
        }

        public void Save () {

            string SQL = "UPDATE Specimen SET CommonName = nullif('" + CommonName + "', ''), Color = nullif('" + Color + "', ''), Form = nullif('" + Form + "', ''), Weight = nullif('" + Weight + "', ''), Origin = nullif('" + Origin + "', '') WHERE ID=" + ID;
            DBEngine.Execute(SQL);

        }

        public void Delete () {

            string sqldel = "SELECT * FROM Specimen Where specimen.ID=" + ID.ToString();
            DataTable dt = DBEngine.GetTable(sqldel);
            if (dt.Rows.Count == 0) {
                MessageBox.Show("You cannot delete this Specimen!");
            }
            else {
                string SQL = "DELETE FROM SpecimenClass WHERE SpecimenID=" + ID.ToString();
                DBEngine.Execute(SQL);
                SQL = "delete from inclusion where specimenid=" + ID.ToString();
                DBEngine.Execute(SQL);
                SQL = "delete from impurity where specimenid=" + ID.ToString();
                DBEngine.Execute(SQL);
                SQL = "Delete from specimen where specimen.ID=" + ID.ToString();
                DBEngine.Execute(SQL);
            }
        }

        public int ID => (int) _Row["ID"];
        public string CommonName {
            get {
                return _Row["CommonName"].ToString();
            }
            set {
                _Row["CommonName"] = value;
            }
        }
        public string Color {
            get {
                return _Row["Color"].ToString();
            }
            set {
                _Row["Color"] = value;
            }
        }
        public string Form {
            get {
                return _Row["Form"].ToString();
            }
            set {
                _Row["Form"] = value;
            }
        }
        public string Weight {
            get {
                return _Row["Weight"].ToString();
            }
            set {
                _Row["Weight"] = value;
            }
        }
        public string Origin {
            get {
                return _Row["Origin"].ToString();
            }
            set {
                _Row["Origin"] = value;
            }
        }
    }
}
