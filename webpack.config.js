const path = require("path");

const HtmlWebpackPlugin = require("html-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const OptimizeCssAssetsPlugin = require("optimize-css-assets-webpack-plugin");
const WebpackCleanupPlugin = require("webpack-cleanup-plugin");

const { DefinePlugin } = require("webpack");

const packageJson = require("./package.json");

const projectRoot = __dirname;

module.exports = function (env, argv) {
    const production = argv.mode === "production";
    return {
        devtool: production ? "source-map" : "eval-source-map",
        output: {
            path: path.join(projectRoot, "build"),
            filename: "[name].[hash].js",
        },
        plugins: [
            new WebpackCleanupPlugin(),
            new HtmlWebpackPlugin(
                {
                    title: packageJson.description,
                    hash: true,
                    template: "./src/index.html",
                },
            ),
        ],
        resolve: {
            extensions: [".js", ".jsx", ".ts", ".tsx"],
        },
        module: {
            rules: [
                {
                    test: /\.css$/,
                    loader: [MiniCssExtractPlugin.loader, "css-loader", "postcss-loader"],
                },
                {
                    test: /\.html$/,
                    loader: "html-loader",
                },
                {
                    test: /\.svg$/,
                    loader: "file-loader",
                },
                {
                    test: /\.txt$/i,
                    use: "raw-loader",
                },
            ],
        },
    };
};
