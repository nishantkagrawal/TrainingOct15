
namespace TypeScriptTest {

    describe("Learning TypeScript, UnderScroreJs and Jasmine", () => {

        it("should find the largest prime factor of a composite number", () => {

            var pr = new PrimeNumber();
            expect(pr.largestPrime(1000)).toBe(5);
            expect(pr.largestPrime(999)).toBe(3);

        });

        it("should find the largest palindrome made from the product of two 3 digit numbers", () => {
            expect(1).toBe(1);
        });

        it("should find the smallest number divisible by each of the numbers 1 to 20", () => {

            expect(1).toBe(2);
        });

        it("should find the difference between the sum of the squares and the square of the sums", () => {
            expect(1).toBe(1);
        });

        it("should find the 10001st prime", () => {
            expect(1).toBe(1);
        })
    });
}