using System.Data;

namespace LibrarySystem324.Model {
    internal class MetalDefinition {
        private readonly DataRow _Row;
        private readonly DataRow _Alloys;
        public MetalDefinition(DataRow aRow) {
            string Name = (string)aRow["name"];
            DataTable dt = DBEngine.GetTable("Select * From Metal where Name=" + Name);

            _Row = dt.Rows[0];
        }
        public static DataTable GetTableWithAlloys() {
            string SQL = "select Metal.*, ifnull(group_concat(concat('', MetalConstituent, ': ', " +
                "ifnull(concat('', MetalPercent, '%'), 'NA')) separator ', '), 'NA') as 'Alloy: Percent' " +
                "from metal left join alloyed on Alloyed.MetalAlloy = metal.name group by name";
            DataTable tbl = DBEngine.GetTable(SQL);
            return tbl;
        }
        public static DataTable GetTableCompact() {
            string SQL = "select m.name, concat_ws(', ', concat('', 'Chem. Formula: ',m.chemicalcomposition), " +
                "concat('', 'Hardness: ',m.hardness), concat('', 'Luster: ',m.Luster), concat('', 'Malleability: ',m.Malleability), " +
                "concat('', 'Ductility: ',m.ductility)) as 'Info', ifnull(group_concat(" +
                "concat('', MetalConstituent, ': ', ifnull(concat('', MetalPercent, '%'), 'NA')) separator ', '), 'NA') " +
                "as 'Alloy: Percent' from metal m left join alloyed on Alloyed.MetalAlloy = m.name group by name";
            DataTable tbl = DBEngine.GetTable(SQL);
            return tbl;
        }
        public static DataTable Search(string filter) {
            string SQL = "select * from Metal";
            if (filter.Trim() != "") { SQL += "where " + filter.Trim(); }
            DataTable tbl = DBEngine.GetTable(SQL);
            return tbl;
        }
        public static DataRow AlloyConcat(string Name) {
            string SQL = "select MetalAlloy, group_concat(concat('', MetalConstituent, ': ', ifnull(concat('', MetalPercent, '%'), 'NA')) separator ', ')" +
                " as 'Alloy: Percent' from Alloyed where MetalAlloy = '" + Name + "' group by MetalAlloy";
            DataTable tbl = DBEngine.GetTable(SQL);
            return tbl.Rows[0];
        }
        public static void CreateNew(string Name) {//
            string SQL = "INSERT INTO Metal(Name, ChemicalComposition, Hardness, Luster, Malleability, Ductility) " +
                "VALUES('" + Name + "', '', '', '', '', '')";
            DBEngine.Execute(SQL);
        }
        public void Save() {
            string SQL = "UPDATE Metal SET ChemicalComposition='" + ChemicalComposition +
                "', Hardness=" + Hardness + ", Luster=" + Luster + ", Malleability=" + Malleability + ", Ductility=" + Ductility +
                " WHERE Name='" + Name + "'";
            DBEngine.Execute(SQL);
        }
        public static void Insert(string Name, string ChemicalComposition = "", string Hardness = "", string Luster = "", string Malleability = "", string Ductility = "") {
            string SQL = "insert into Metal(Name, ChemicalComposition, Hardness, Luster, Malleability, Ductility)" +
                "VALUES('" + Name + "', '" + ChemicalComposition + "', '" + Hardness + "', '" + Luster + "', '" + Malleability + "', '" + Ductility + "')";
            DBEngine.Execute(SQL);
        }
        public string Name {
            get {
                return (string)_Row["Name"];
            }
            set {
                _Row["Name"] = value;
            }
        }
        public string ChemicalComposition {
            get {
                return (string)_Row["ChemicalComposition"];
            }
            set {
                _Row["ChemicalComposition"] = value;
            }
        }
        public string Hardness {
            get {
                return (string)_Row["Hardness"];
            }
            set {
                _Row["Hardness"] = value;
            }
        }
        public string Luster {
            get {
                return (string)_Row["Luster"];
            }
            set {
                _Row["Luster"] = value;
            }
        }
        public string Malleability {
            get {
                return (string)_Row["Malleability"];
            }
            set {
                _Row["Malleability"] = value;
            }
        }
        public string Ductility {
            get {
                return (string)_Row["Ductility"];
            }
            set {
                _Row["Ductility"] = value;
            }
        }
    }
}
