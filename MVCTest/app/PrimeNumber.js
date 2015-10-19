var TypeScriptTest;
(function (TypeScriptTest) {
    var PrimeNumber = (function () {
        function PrimeNumber() {
            var _this = this;
            this.getFactors = function (input) {
                var rangeToIterate = _.range(Math.round(Math.sqrt(input)), 1, -1);
                //find factors
                var factors = _.filter(rangeToIterate, function (num) {
                    return input % num === 0;
                });
                return factors;
            };
            this.isPrime = function (input) {
                return _this.getFactors(input).length === 0;
            };
            this.largestPrime = function (input) {
                var allFactors = _this.getFactors(input);
                console.log(allFactors);
                var primeFactors = _.filter(allFactors, _this.isPrime);
                console.log(primeFactors);
                return _.max(primeFactors);
            };
        }
        return PrimeNumber;
    })();
    TypeScriptTest.PrimeNumber = PrimeNumber;
})(TypeScriptTest || (TypeScriptTest = {}));
//# sourceMappingURL=PrimeNumber.js.map