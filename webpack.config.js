const path = require("path");

const HtmlWebpackPlugin = require("html-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const OptimizeCssAssetsPlugin = require("optimize-css-assets-webpack-plugin");
const WebpackCleanupPlugin = require("webpack-cleanup-plugin");
const { DefinePlugin } = require("webpack");

const packageJson = require("./package.json");

const projectRoot = __dirname;

const version = (v, em) => (em === "production" ? v : `${ v }-dev`);

module.exports = function (env, argv) {
    const production = argv.mode === "production";
    return {
        devtool: production ? "source-map" : "eval-source-map",
        devServer: {
            overlay: true,
        },
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
                    minify: {
                        collapseWhitespace: true,
                    },
                },
            ),
            new MiniCssExtractPlugin(
                {
                    filename: "[name].[hash].css",
                },
            ),
            new OptimizeCssAssetsPlugin(),
            new DefinePlugin(
                {
                    APPNAME: JSON.stringify(packageJson.name),
                    APPTITLE: JSON.stringify(packageJson.description),
                    DEBUG: JSON.stringify(!production),
                    PRODUCTION: JSON.stringify(production),
                    RELEASE: JSON.stringify(`${ packageJson.name }@${ version(packageJson.version, argv.mode) }`),
                    SENTRY_CONFIG: JSON.stringify(packageJson.sentry),
                    VERSION: JSON.stringify(version(packageJson.version, argv.mode)),
                },
            ),
        ],
        resolve: {
            extensions: [".js", ".jsx", ".ts", ".tsx"],
        },
        module: {
            rules: [
                {
                    exclude: /node_modules\/(?!(bmo)\/).*/,
                    test: /\.(js|jsx)$/,
                    loader: ["babel-loader", ...(production ? ["eslint-loader"] : [])],
                },
                {
                    exclude: /node_modules\/(?!(bmo)\/).*/,
                    test: /\.(ts|tsx)$/,
                    loader: [
                        "babel-loader",
                        {
                            loader: "ts-loader",
                            options: {
                                allowTsInNodeModules: true,
                            },
                        },
                        ...(production ? ["tslint-loader"] : []),
                    ],
                },
                {
                    test: /\.css$/,
                    loader: [MiniCssExtractPlugin.loader, "css-loader", "postcss-loader"],
                },
                {
                    test: /\.less$/,
                    loader: [MiniCssExtractPlugin.loader, "css-loader", "postcss-loader", "less-loader"],
                },
                {
                    test: /\.html$/,
                    loader: "html-loader",
                },
                {
                    test: /\.svg$/,
                    loader: "file-loader",
                },
            ],
        },
    };
};
