class Tickets{
    #tickets = {};

    Add(seat, flight, departurePort, arrivalPort, date) {

        if (this.Get(seat, flight) != null)
            return false;
       
        const ticket = {seat, flight, departurePort, arrivalPort, date};
        this.#tickets[`${seat}_${flight}`] = ticket;
        return true;
    }

    Get(seat, flight) {
        return this.#tickets[`${seat}_${flight}`];
    }    

    Update(seat, flight, departurePort, arrivalPort, date) {
        
        if (this.Get(seat, flight) == null)
            return false;
       
        this.#tickets[`${seat}_${flight}`] = {seat, flight, departurePort, arrivalPort, date};
        return true;
    }
}

module.exports = {
    Tickets
}