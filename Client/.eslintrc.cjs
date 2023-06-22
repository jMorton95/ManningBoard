module.exports = {
  env: {
    browser: true,
    es2021: true,
  },
  extends: [
    'next/core-web-vitals',
    'standard-with-typescript',
    'plugin:react/recommended',
  ],
  parserOptions: {
    ecmaVersion: 'latest',
    sourceType: 'module',
    project: './tsconfig.json',
  },
  plugins: [
    'react',
  ],
  rules: {
    'prettier/prettier': 'off',
    semi: ['warn', 'always',],
    '@typescript-eslint/semi': ['off', 'never',],
    indent: ['warn', 2, {
      SwitchCase: 1,
      VariableDeclarator: { var: 2, let: 2, const: 3, },
      ignoredNodes: ['ConditionalExpression',],
    },
    ],
    'comma-dangle': ['off', 'off',],
    'react/react-in-jsx-scope': 'off',
    'space-before-function-paren': ['off', 'off',],
    '@typescript-eslint/space-before-function-paren': ['off', 'off',],
    'spaced-comment': ['error', 'never',],
    '@typescript-eslint/consistent-type-definitions': ['error', 'type',],
  },
};
