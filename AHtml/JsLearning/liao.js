class Student
{
	constructor(name){
		this.name=name;
	}
	hello()
	{
		alert('hello',+this.name);
	}
}
class PrimaryStudent extends Student{
	constructor(name,grade)
	{
		super(name);
		this.grade=grade;
	}
	myGrade(){
		alert('grade:'+this.grade)
	}
}