if (typeof SiteMetrics !== typeof undefined && SiteMetrics.baseUrl) {
    window.addEventListener("click", function (args) {
        const meterName = args.target.dataset.meterName;

        if (meterName && args.target.tagName === "A") {
            try {
                _ = fetch(`${SiteMetrics.baseUrl}/githubpages/metrics`, {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json;charset=utf-8"
                    },
                    body: JSON.stringify({ "MeterName": meterName })
                });
            } catch (error) {
                if (SiteMetrics.showError) {
                    console.debug(`Fetch error: ${error.message}`);
                }
            }
        }
    }, false);
}
