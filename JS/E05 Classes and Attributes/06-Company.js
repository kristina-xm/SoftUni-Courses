class Company {

    constructor() {
        this.departments = {};
    }

    addEmployee(name, salary, position, department) {

        //Validation
        let args = [name, salary, position, department];

        if (salary < 0) {
            throw new Error("Invalid input!");
        }

        const invalidInputs = (input) => input === '' || input === undefined || input === null;

        if (args.some(invalidInputs)) {
            throw new Error("Invalid input!");
        }

        //Adding employees
        let employeeInfo = { name, salary, position };

        //If department does not exist
        if (!this.departments.hasOwnProperty(department)) {

            let arrOfEmployess = [];

            arrOfEmployess.push(employeeInfo);

            this.departments[department] = arrOfEmployess;

            return `New employee is hired. Name: ${name}. Position: ${position}`

        } else {

            //Add the new employee to already existing department
            this.departments[department].push(employeeInfo);
            return `New employee is hired. Name: ${name}. Position: ${position}`
        }

    }

    bestDepartment() {

        //New obj to save only the best department
        let bestDep = {};

        let sumOfSalaries = Number.MIN_VALUE;

        //All salaries
        let sum = 0;

        //Variable only to keep the average value 
        let avgSalary = 0;

        for (let department in this.departments) {

            //All salaries for the current department
            for (let employees of this.departments[department]) {
                sum += employees.salary;
            }

            //average value
            sum /= this.departments[department].length;

            //if average value is grater than the curr one
            if (sum > sumOfSalaries) {

                //set best department the curr one
                bestDep = {
                    'name': department,
                    'employeesData': this.departments[department]
                }

                //copy the value
                avgSalary = sum;

                //set the average salary of the best one for the 
                //biggest until we receive a bigger one
                sumOfSalaries = sum;
             
            }
            //ready to calculate the value for the next department
            sum = 0;
        }

        function sortBySalaray(a, b) {

            //Firstly - sort by salary
            if (a.salary !== b.salary) {
                return b.salary - a.salary;
            } else {
                //Then - sort by name if their salaries are equal
                let firstName = a.name;
                let secondName = b.name;
                return firstName.localeCompare(secondName);
            }
        }

        let sorted = bestDep.employeesData.sort(sortBySalaray);

        //save the information in a suitable format for return
        let sortedInfo = [];

        for (let info of sorted) {

            sortedInfo.push(`${info.name} ${info.salary} ${info.position}`);
        }

        return `Best Department is: ${bestDep.name}\nAverage salary: ${avgSalary.toFixed(2)}\n${sortedInfo.join('\n')}`;

    }

}


