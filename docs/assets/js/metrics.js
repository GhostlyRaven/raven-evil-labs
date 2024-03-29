if (typeof SiteMetrics !== typeof undefined && SiteMetrics.baseUrl) {
    const handler = async function (args) {
        const meterName = args.target.dataset.meterName;

        if (meterName && args.target.tagName === "A") {
            try {
                _ = await fetch(SiteMetrics.baseUrl, {
                    method: "POST",
                    headers: {
                        "Content-Type": "text/plain;charset=utf-8"
                    },
                    body: meterName
                });
            } catch (error) {
                if (SiteMetrics.showError) {
                    console.debug(`Fetch error: ${error.message}`);
                }
            }
        }
    }

    window.addEventListener("click", handler, false);
    window.addEventListener("auxclick", handler, false);
}
