if (typeof SiteMetrics !== typeof undefined && SiteMetrics.baseUrl) {
    window.addEventListener("click", async function (args) {
        const meterName = args.target.dataset.meterName;

        if (meterName && args.target.tagName === "A") {
            try {
                _ = await fetch(`${SiteMetrics.baseUrl}/githubpages/metrics`, {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json;charset=utf-8"
                    },
                    body: JSON.stringify({ "MeterName": meterName }),
                    referrerPolicy: "no-referrer"
                });
            } catch (error) {
                if (SiteMetrics.showError) {
                    console.debug(`Fetch error: ${error.message}`);
                }
            }
        }
    }, false);
}
