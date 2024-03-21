Champion bob = new Champion ("Bob",100,20);
Champion john = new Champion ("John",100,20);
bob.Attack(john);
BladeMaster jack = new BladeMaster("jack");
jack.Attack(john);
jack.Attack(john);
jack.Attack(bob);

ElementalMage gandalf = new ElementalMage("Gandalf") ;
gandalf.Attack(bob);
gandalf.FireBall(john);