class Account {
    constructor(Acc_no: number, Balance: number) {}

    debitAmount() {}
    creditAmount() {}
    getBalance() {}
}

interface IAccount {
    Date_of_opening:number;
    addCustomer()
    removeCustomer()
}

class CurrentAccount extends Account implements IAccount {
    constructor (Acc_no: number, Balance: number, Interest_rate: number) {
        super(Acc_no, Balance);
    }
    Date_of_opening: number;
    
    addCustomer() {
        throw new Error("Method not implemented.");
    }
    removeCustomer() {
        throw new Error("Method not implemented.");
    }
}

class SavingAccount extends Account implements IAccount {
    constructor (Acc_no: number, Balance: number, Min_Balance: number) {
        super(Acc_no, Balance);
    }
    Date_of_opening: number;
    addCustomer() {
        throw new Error("Method not implemented.");
    }
    removeCustomer() {
        throw new Error("Method not implemented.");
    }
}