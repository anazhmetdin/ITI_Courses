var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var Account = /** @class */ (function () {
    function Account(Acc_no, Balance) {
    }
    Account.prototype.debitAmount = function () { };
    Account.prototype.creditAmount = function () { };
    Account.prototype.getBalance = function () { };
    return Account;
}());
var CurrentAccount = /** @class */ (function (_super) {
    __extends(CurrentAccount, _super);
    function CurrentAccount(Acc_no, Balance, Interest_rate) {
        return _super.call(this, Acc_no, Balance) || this;
    }
    CurrentAccount.prototype.addCustomer = function () {
        throw new Error("Method not implemented.");
    };
    CurrentAccount.prototype.removeCustomer = function () {
        throw new Error("Method not implemented.");
    };
    return CurrentAccount;
}(Account));
var SavingAccount = /** @class */ (function (_super) {
    __extends(SavingAccount, _super);
    function SavingAccount(Acc_no, Balance, Min_Balance) {
        return _super.call(this, Acc_no, Balance) || this;
    }
    SavingAccount.prototype.addCustomer = function () {
        throw new Error("Method not implemented.");
    };
    SavingAccount.prototype.removeCustomer = function () {
        throw new Error("Method not implemented.");
    };
    return SavingAccount;
}(Account));
