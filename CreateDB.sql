--CREATE DATABASE Test_Stimulus_Graph;

CREATE TABLE Graphe
(
	id	INT	NOT NULL,
	nom	VARCHAR(50)	NOT NULL,
	statut	VARCHAR(10)	NOT NULL
);

CREATE TABLE Noeud
(
	id	INT	NOT NULL,
	nom		VARCHAR(20)	NOT NULL,
	graph_id	INT	NOT NULL,
	liaison_parent INT NULL,
	posx	INT		NOT NULL,
	posy	INT		NOT NULL,
	rayon	INT		NOT NULL,
	couleur	VARCHAR(15)	NOT NULL,
);

CREATE TABLE Liaison_enfant
(
	noeud_parent	INT	NOT NULL,
	noeud_enfant	INT	NOT NULL
);

ALTER TABLE Graphe
ADD PRIMARY KEY (id);

ALTER TABLE Noeud
ADD PRIMARY KEY (id);




ALTER TABLE Noeud
ADD FOREIGN KEY (graph_id) REFERENCES Graphe(id);
ALTER TABLE Noeud
ADD FOREIGN KEY (liaison_parent) REFERENCES Noeud(id);
ALTER TABLE Liaison_enfant
ADD FOREIGN KEY (noeud_parent) REFERENCES Noeud(id);
ALTER TABLE Liaison_enfant
ADD FOREIGN KEY (noeud_enfant) REFERENCES Noeud(id);
