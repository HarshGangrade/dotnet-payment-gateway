async function processPayment() {
    const amountInput = document.getElementById("amount").value;
    const resultDiv = document.getElementById("result");

    if (!amountInput || amountInput <= 0) {
        resultDiv.innerHTML = "<p style='color:red;'>Please enter a valid amount</p>";
        return;
    }

    const paymentData = {
        amount: parseFloat(amountInput)
    };

    try {
        const response = await fetch("https://localhost:7024/api/Payments/process", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(paymentData)
        });

        if (!response.ok) {
            throw new Error("API error");
        }

        const data = await response.json();

        resultDiv.innerHTML = `
            <p><strong>Status:</strong> ${data.status}</p>
            <p><strong>Original Amount:</strong> ₹${data.originalAmount}</p>
            <p><strong>Final Amount:</strong> ₹${data.finalAmount}</p>
            <p><strong>Fee Applied:</strong> ${data.feeApplied ? "Yes" : "No"}</p>
        `;
    } catch (error) {
        resultDiv.innerHTML = "<p style='color:red;'>Error connecting to server</p>";
    }
}
