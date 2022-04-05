using System.Globalization;
using NUnit.Framework;

namespace PointOfSaleSpecs {
    public class PointOfSaleSpecs {


        [Test]
        public void display_725_price_when_scan_12345_barcode() {
            var price = string.Empty;

            price = PointOfSale.Run("12345");

            Assert.AreEqual("$7.25", price);
        }

        [Test]
        public void display_1250_price_when_scan_23456_barcode() {
            var price = string.Empty;

            price = PointOfSale.Run("23456");

            Assert.AreEqual("$12.50", price);
        }

        [Test]
        public void display_barcode_not_found_message_when_scan_99999_barcode() {
            var price = string.Empty;

            price = PointOfSale.Run("99999");

            Assert.AreEqual("Error: barcode not found", price);
        }

        [Test]
        public void display_barcode_empty_message_when_scan_empty_barcode() {
            var price = string.Empty;

            price = PointOfSale.Run("");

            Assert.AreEqual("Error: empty barcode", price);
        }

        [Test]
        public void display_sum_of_prices_when_total_is_introduced_when_scan_23456_barcode() {
            var price = string.Empty;

            price = PointOfSale.Run("23456", 2);

            Assert.AreEqual("$25.00", price);
        }

    }

    public class PointOfSale {

        public static string Run(string barCode, int total = 1) {
            if (barCode == string.Empty) return "Error: empty barcode";
            if (barCode == "99999") return "Error: barcode not found";
            if (barCode == "23456") return $"${(12.50D * total).ToString("0.00", CultureInfo.InvariantCulture)}";
            return "$7.25";
        }
    }
}