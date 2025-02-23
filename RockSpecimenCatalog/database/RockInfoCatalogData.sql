insert into Specimen (ID) values
(1), (2), (3), (4), (5);

insert into 
	gemstone (gemstone.Name)
values
	('testGemA'), ('testGemB'), ('testGemC'), ('testGemD'), ('testGemE')
;
insert into
	metal (Name)
values
	('testMetalA'), ('testMetalB'), ('testMetalC'), ('testMetalD'), ('testMetalE')
;
insert into
	rock (Name)
values
	('testRockA'), ('testRockB'), ('testRockC'), ('testRockD'), ('testRockE')
;
insert into
	mineral (Name)
values
	('testMineralA'), ('testMineralB'), ('testMineralC'), ('testMineralD'), ('testMineralE')
;
insert into
	specimenclass (SpecimenID, GemstoneName, MetalName, RockName, MineralName)
values
	(1,'testGemA',null,null,null),
	(2,null,null,null,'testMineralA'),
    (2,null,null,null,'testMineralB'),
    (3,null,null,'testRockC',null),
    (4,null,'testMetalD',null,null),
    (5,null,null,null,'testMineralA')
;
insert into 
	alloyed (MetalAlloy, MetalConstituent)
values
	('testMetalA', 'testMetalB'),
    ('testMetalA', 'testMetalC'),
    ('testMetalE', 'testMetalB'),
    ('testMetalE', 'testMetalC'),
    ('testMetalE', 'testMetalD')
;
insert into 
	composites (RockName, GemstoneName, MineralName)
values
	('testRockC', null, 'testMineralA'),
    ('testRockC', null, 'testMineralB'),
    ('testRockC', null, 'testMineralC'),
    (null, 'testGemA', 'testMineralD'),
    (null, 'testGemA', 'testMineralE')
;
insert into 
	impurity (specimenid, metalname, mineralname)
values
	(2, 'testMetalB', null),
    (2, 'testMetalC', null),
    (5, 'testMetalB', null),
    (5, 'testMetalD', null),
    (5, null, 'testMineralA')
;
insert into 
	inclusion (specimenid, metalname, rockname, mineralname)
values
	(1, 'testMetalC', null, null),
    (1, null, 'testRockA', null),
    (2, 'testMetalD', null, null),
    (2, null, null, 'testMineralC'),
    (2, null, null, 'testMineralE')
;

insert into 
	userverification (email, userPassword)
values
	('aa', 'aa')
;

UPDATE Specimen 
SET CommonName = nullif('" + CommonName + "', ''),
Color = nullif('" + Color + "', ''), 
Form = nullif('" + Form + "', ''), 
Weight = nullif('" + Weight + "', ''), 
Origin = nullif('' '') 
WHERE ID=6;

Select * from specimen;
Select * from metal;
Select * from rock;
Select * from gemstone;
Select * from mineral;
Select * from specimenclass;
Select * from alloyed;
Select * from composites;
Select * from impurity;
Select * from inclusion;

Select s.id, concat_ws('', g.name, mt.name, r.name, ml.name) as name from specimen s
join specimenclass sc on sc.SpecimenID = s.id
left join gemstone g on g.name = sc.GemstoneName
left join metal mt on mt.name = sc.MetalName
left join rock r on r.name = sc.RockName
left join mineral ml on ml.name = sc.MineralName
;

select s.*,  classifications from specimen s
where s.id = (select sc.specimenid from specimenclass);

select s.*, concat_ws(', ', group_concat(sc.gemstonename separator ', '), group_concat(sc.metalname separator ', '), group_concat(sc.rockname separator ', '), group_concat(sc.mineralname separator ', ')) as Classifications
from specimenclass sc
join specimen s on sc.SpecimenID = s.id
group by s.ID;

select * from metal;
select Metal.*, group_concat(concat('', MetalConstituent, ': ', ifnull(concat('', MetalPercent, '%'), 'NA')) separator ', ') as 'Alloy: Percent' from Alloyed join metal on Alloyed.MetalAlloy = metal.name group by MetalAlloy;
select Metal.*, ifnull(group_concat(concat('', MetalConstituent, ': ', ifnull(concat('', MetalPercent, '%'), 'NA')) separator ', '), 'NA') as 'Alloy: Percent' from metal left join alloyed on Alloyed.MetalAlloy = metal.name group by name;
select m.name, concat_ws(', ', concat('', 'Chem. Formula: ',m.chemicalcomposition), concat('', 'Hardness: ',m.hardness), concat('', 'Luster: ',m.Luster), concat('', 'Malleability: ',m.Malleability), concat('', 'Ductility: ',m.ductility)) as 'Info', ifnull(group_concat(concat('', MetalConstituent, ': ', ifnull(concat('', MetalPercent, '%'), 'NA')) separator ', '), 'NA') as 'Alloy: Percent' from metal m left join alloyed on Alloyed.MetalAlloy = m.name group by name;