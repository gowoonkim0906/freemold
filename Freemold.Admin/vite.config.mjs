
import { defineConfig } from "vite";

export default defineConfig({
    build: {
        outDir: "wwwroot/js/vendor",
        emptyOutDir: true,
        lib: {
            entry: "ClientApp/vendor-lit.js",
            formats: ["es"],
            fileName: () => "lit.js"
        }
    }
});