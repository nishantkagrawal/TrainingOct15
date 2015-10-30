namespace TypeScriptTest {
    export class PrimeNumber {
        constructor() {
        }

        private getFactors = (input) => {
            var rangeToIterate = _.range(Math.round(Math.sqrt(input)), 1, -1);

            //find factors
            var factors = _.filter(rangeToIterate, (num) => {
                return input % num === 0;
            });

            return factors;
        };

        private isPrime = (input) => {
            return this.getFactors(input).length === 0;
        }

        public largestPrime = (input) => {
            var allFactors = this.getFactors(input);
            console.log(allFactors);
            var primeFactors = _.filter(allFactors, this.isPrime);
            console.log(primeFactors);
            return _.max(primeFactors);
        }
    }
}