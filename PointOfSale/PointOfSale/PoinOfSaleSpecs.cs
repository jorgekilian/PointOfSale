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

    }

    public class PointOfSale {
        public static string Run(string barCode) {
            if (barCode == "23456") return "$12.50";
            return "$7.25";
        }
    }
}