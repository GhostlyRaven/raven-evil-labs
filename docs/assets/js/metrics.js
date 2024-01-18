if (typeof SiteMetrics !== typeof undefined && SiteMetrics.baseUrl) {
    window.addEventListener("click", async function (args) {
        const meterName = args.target.dataset.meterName;

        if (meterName && args.target.tagName === "A") {
            try {
                const client = new XMLHttpRequest();

                client.open("POST", `${SiteMetrics.baseUrl}/githubpages/metrics`, true);
                client.setRequestHeader("Content-Type", "application/json");
                client.send(JSON.stringify({ "MeterName": meterName }));
            } catch (error) {
                if (SiteMetrics.showError) {
                    console.debug(`Fetch error: ${error.message}`);
                }
            }
        }
    }, false);
}
