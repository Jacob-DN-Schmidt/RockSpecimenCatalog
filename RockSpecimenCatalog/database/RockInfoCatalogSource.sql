create database RockInfoCatalog;
use RockInfoCatalog;
create table Specimen (
	ID int primary key auto_increment,
    CommonName varchar(50),
    Color varchar(15),
    Form varchar(15),
    Weight varchar(15),
    Origin varchar(50)
);
alter table specimen modify column color varchar(50);
alter table specimen modify column weight varchar(25);
alter table specimen modify column Form varchar(25);

alter table metal modify column Alloy boolean default 0;
update metal set alloy = 0 where alloy is null and name like 'testMetal%';
alter table metal drop column alloy;
create table Metal (
	Name varchar(50) primary key,
    ChemicalComposition varchar(75),
    Hardness varchar(25),
    Luster varchar(25),
    Malleability varchar(25),
    Ductility varchar(25),
    Alloy boolean default 0
);


create table Rock (
	Name varchar(50) primary key,
	FormationGroup enum("Igneous", "Sedimentary", "Metamorphic"),
    Texture varchar(50),
    MiscInfo varchar(75)
);

create table Gemstone (
	Name varchar(50) primary key,
    ChemicalComposition varchar(75),
    Structure varchar(50),
    MiscInfo varchar(75)
);
alter table gemstone modify column miscinfo varchar(250);

create table Mineral (
	Name varchar(50) primary key,
    ChemicalComposition varchar(75),
    Structure varchar(50),
    Hardness varchar(25),
    Clevage varchar(25),
    Luster varchar(25)
);

create table SpecimenClass (
	SpecimenID int not null references Specimen(ID),
    GemstoneName varchar(50) references Gemstone(Name),
    MetalName varchar(50) references Metal(Name),
    RockName varchar(50) references Rock(Name),
    MineralName varchar(50) references Mineral(Name),
    check (GemstoneName is not null xor MetalName is not null xor RockName is not null xor MineralName is not null),
    unique (SpecimenID, (concat_ws('', GemstoneName, MetalName, RockName, MineralName)))
);

create table Alloyed (
	MetalAlloy varchar(50) references Metal(Name),
    MetalConstituent varchar(50) references Metal(Name),
    MetalPercent decimal(2,2),
    primary key (MetalAlloy, MetalConstituent)
);

create table Composites (
	RockName varchar(50) references Rock(Name),
    GemstoneName varchar(50) references Gemstone(Name),
    MineralName varchar(50) not null references Mineral(Name),
    MineralPercent decimal(2,2),
    check (RockName is not null xor GemstoneName is not null),
    unique ((concat_ws('', RockName, GemstoneName)), MineralName)
);

create table Impurity (
	SpecimenID int not null references Specimen(ID),
    MetalName varchar(50) references Metal(Name),
    MineralName varchar(50) references Mineral(Name),
    ImpurityType varchar(25),
    PPM int,
    check (MetalName is not null xor MineralName is not null),
    unique (SpecimenID, (concat_ws('', MetalName, MineralName)))
);

create table Inclusion (
	SpecimenID int not null references Specimen(ID),
    MetalName varchar(50) references Metal(Name),
    RockName varchar(50) references Rock(Name),
    MineralName varchar(50) references Mineral(Name),
    InclusionType varchar(25),
    Characterization varchar(75),
    check (MetalName is not null xor RockName is not null xor MineralName is not null),
    unique (SpecimenID, (concat_ws('', MetalName, RockName, MineralName)))
);

create table UserVerification (
	UserID int primary key auto_increment,
    email varchar(50) not null,
    userPassword varchar(50) not null
);

create view SpecimenWithClassification as 
select s.ID as ID, s.CommonName as 'Common Name', s.color as 'Color', s.form as 'Form', s.weight as 'Weight', s.origin as 'Origin', 
concat_ws(', ', group_concat(sc.gemstonename separator ', '), group_concat(sc.metalname separator ', '), 
group_concat(sc.rockname separator ', '), group_concat(sc.mineralname separator ', ')) as Classifications 
from specimen s left join specimenclass sc on sc.SpecimenID = s.id group by s.ID;
create view DefinedGemstones as select name from gemstone;
create view DefinedMetal as select name from metal;
create view DefinedRock as select name from rock;
create view DefinedMineral as select name from mineral;
select * from DefinedGemstones, DefinedMetal, DefinedRock, DefinedMineral;

describe specimen;
describe metal;
describe rock;
describe gemstone;
describe mineral;
describe specimenclass;
describe alloyed;
describe composites;
describe impurity;
describe inclusion;

select * from SpecimenWithClassification;
select group_concat(gemstone.Name separator ', ') from gemstone;
select group_concat(Gemstone.Name separator ', ') as 'Defined Gemstones', group_concat(Metal.Name separator ', ') as 'Defined Metals', group_concat(Rock.Name separator ', ') as 'Defined Rocks', group_concat(Metal.name separator ', ') as 'Defined Minerals' from gemstone, metal, rock, mineral;